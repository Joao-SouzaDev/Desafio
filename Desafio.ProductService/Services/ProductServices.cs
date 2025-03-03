using Desafio.ProductService.Models;
using Desafio.ProductService.Repositories.Interfaces;

namespace Desafio.ProductService.Services
{
    public class ProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public async void DeleteProduct(Guid productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product != null)
            {
                _productRepository.DeleteProduct(product);
            }
            throw new Exception("Product not found");
        }

        public Task<Product?> GetProductById(Guid id)
        {
            return _productRepository.GetProductById(id);
        }

        public Task<IEnumerable<Product>> GetProductsByOwnerId(Guid ownerId)
        {
            return _productRepository.GetProductsByOwnerId(ownerId);
        }
        public Task<IEnumerable<Product>> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}
