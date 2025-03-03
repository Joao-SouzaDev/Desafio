using AutoMapper;
using Desafio.ProductService.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Desafio.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOwnerController : ControllerBase
    {
        private readonly IProductOwnerRepository _productOwnerRepo;
        private readonly IMapper _mapper;
        public ProductOwnerController(IProductOwnerRepository productOwnerRepo, IMapper mapper)
        {
            _productOwnerRepo = productOwnerRepo;
            _mapper = mapper;
        }

        // GET: api/<ProductOwner>
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductOwner>/5
        [HttpGet("{id}")]
        [Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductOwner>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<ProductOwner>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<ProductOwner>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
