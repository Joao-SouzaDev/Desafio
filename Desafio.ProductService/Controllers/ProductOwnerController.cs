using AutoMapper;
using Desafio.ProductService.Data.DTO;
using Desafio.ProductService.Repositories.Interfaces;
using Desafio.ProductService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOwnerController : ControllerBase
    {
        private readonly ProductOwnerService _productOwnerService;
        private readonly IMapper _mapper;
        public ProductOwnerController(ProductOwnerService productOwnerService, IMapper mapper)
        {
            _productOwnerService = productOwnerService;
            _mapper = mapper;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            var productOwner = await _productOwnerService.GetByUserId(userId);
            return Ok(productOwner);
        }
    }
}
