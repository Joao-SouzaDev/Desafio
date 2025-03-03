using AutoMapper;
using Desafio.AuthService.Data.DTO;
using Desafio.AuthService.Models;
using Desafio.AuthService.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserServices _userRepository;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;

        public AuthController(UserServices userRepository, IMapper mapper, TokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns code="200"></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            try
            {
                await _userRepository.AddUser(user, request.Password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Faz login de um usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns code="200">Retorna o Token Gerado</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _userRepository.Login(request.Email, request.Password);
                return Ok(token);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
        }

        /// <summary>
        /// Valida um token JWT
        /// </summary>
        /// <param name="request"></param>
        /// <returns cod="200">Retorna o Token Validado</returns>
        [HttpPost("validate_token")]
        public IActionResult ValidateToken([FromBody] string request)
        {
            try
            {
                var isValid = _tokenService.ValidateJwtToken(request);
                if (isValid)
                {
                    return Ok();
                }
            }
            catch (SecurityTokenInvalidSignatureException e)
            {
                return Unauthorized(e.Message);
            }
            return Unauthorized();
        }
    }
}