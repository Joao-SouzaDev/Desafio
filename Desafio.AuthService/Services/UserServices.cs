using Desafio.AuthService.Data.DTO;
using Desafio.AuthService.Models;
using Microsoft.AspNetCore.Identity;

namespace Desafio.AuthService.Services
{
    public class UserServices 
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly MqServices _mqServices;
        public UserServices(UserManager<User> userManager, SignInManager<User> signInManager,TokenService tokenService, MqServices mqServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mqServices = mqServices;
        }
        // Metodo para adicionar um usuario
        public async Task AddUser(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Error creating user: {errors}");
            }
            await _mqServices.SendMessageAsync(user.Id);
        }
        // Metodo para deletar um usuario
        public void DeleteUser(User user)
        {
            _userManager.DeleteAsync(user);
        }
        // Metodo para buscar um usuario pelo ID
        public async Task<User?> GetUserById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        // Metodo de login
        public async Task<GetAccesResponse> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }
            var result = await _signInManager.PasswordSignInAsync(user,password,false,false);
            if (result.Succeeded)
            {
                var getAccess = new GetAccesResponse { Token = _tokenService.GenerateJwtToken(user), UserId = user.Id };
                return getAccess;
            }
            throw new UnauthorizedAccessException("Invalid login attempt");
        }
    }
}
