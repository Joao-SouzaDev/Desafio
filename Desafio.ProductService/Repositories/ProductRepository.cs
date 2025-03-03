using Desafio.ProductService.Data;
using Desafio.ProductService.Models;
using Desafio.ProductService.Repositories.Interfaces;

namespace Desafio.ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductServiceContext _context;
        public ProductRepository(ProductServiceContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.FromResult(_context.Products.AsEnumerable());
        }
        public Task<IEnumerable<Product>> GetProductsByOwnerId(Guid ownerId)
        {
            return Task.FromResult(_context.Products.Where(p => p.ProductOwnerId == ownerId).AsEnumerable());
        }
    }
}
