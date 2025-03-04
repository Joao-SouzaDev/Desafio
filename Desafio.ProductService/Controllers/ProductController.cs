using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Desafio.ProductService.Data.DTO;
using Desafio.ProductService.Models;
using Desafio.ProductService.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _productService;
        private readonly IMapper _mapper;
        public ProductController(ProductServices productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            var productsResponse = _mapper.Map<IEnumerable<Product>, IEnumerable<GetProductResponse>>(products);
            return Ok(productsResponse);
        }
        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="createProductRequest">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <respnse code="201">Retorna o produto criado</respnse>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] CreateProductRequest createProductRequest)
        {
            var product = _mapper.Map<CreateProductRequest, Product>(createProductRequest);
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        [Authorize]
        [HttpGet("{ownerId}/products")]
        public async Task<IActionResult> GetByOwnerId(Guid ownerId)
        {
            var products = await _productService.GetProductsByOwnerId(ownerId);
            var productsResponse = _mapper.Map<IEnumerable<Product>, IEnumerable<GetProductResponse>>(products);
            return Ok(productsResponse);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetProductById(id);
            if(product == null) return NotFound();
            var productResponse = _mapper.Map<Product, GetProductResponse>(product);
            return Ok(productResponse);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productService.DeleteProduct(id);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
