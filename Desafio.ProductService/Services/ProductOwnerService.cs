using Desafio.ProductService.Models;
using Desafio.ProductService.Repositories.Interfaces;

namespace Desafio.ProductService.Services
{
    public class ProductOwnerService
    {
        private readonly IProductOwnerRepository _productOwnerRepository;
        public ProductOwnerService(IProductOwnerRepository productOwnerRepository)
        {
            _productOwnerRepository = productOwnerRepository;
        }
        public void AddProductOwner(ProductOwner productOwner)
        {
            _productOwnerRepository.Add(productOwner);
        }
        public IEnumerable<ProductOwner> GetAll()
        {
            return _productOwnerRepository.GetAll();
        }
        public async Task<ProductOwner?> GetProductOwnerById(Guid productOwnerId)
        {
            return await _productOwnerRepository.GetByIdAsync(productOwnerId);
        }
        public void UpdateProductOwner(ProductOwner productOwner)
        {
            _productOwnerRepository.Update(productOwner);
        }
        public void DeleteProductOwner(ProductOwner productOwner)
        {
            _productOwnerRepository.Delete(productOwner);
        }
    }
}
