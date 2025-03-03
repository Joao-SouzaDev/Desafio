using Desafio.ProductService.Models;

namespace Desafio.ProductService.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public void DeleteProduct(Product product);
        public Task<Product?> GetProductById(Guid id);
        public Task<IEnumerable<Product>> GetProductsByOwnerId(Guid ownerId);
        public Task<IEnumerable<Product>> GetAll();
    }
}
