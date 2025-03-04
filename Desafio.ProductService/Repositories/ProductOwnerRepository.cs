using Desafio.ProductService.Data;
using Desafio.ProductService.Models;
using Desafio.ProductService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Desafio.ProductService.Repositories
{
    public class ProductOwnerRepository : IProductOwnerRepository
    {
        private readonly ProductServiceContext _context;
        public ProductOwnerRepository(ProductServiceContext context)
        {
            _context = context;
        }
        public void Add(ProductOwner productOwner)
        {
            _context.ProductOwners.Add(productOwner);
            _context.SaveChanges();
        }

        public void Delete(ProductOwner productOwner)
        {
            _context.ProductOwners.Remove(productOwner);
            _context.SaveChanges();
        }

        public IEnumerable<ProductOwner> GetAll()
        {
            return _context.ProductOwners.AsEnumerable();
        }
        public async Task<ProductOwner?> GetByUserId(Guid userId)
        {
            return await _context.ProductOwners.FirstOrDefaultAsync(x => x.UserId == userId);
        }
        public async Task<ProductOwner?> GetByIdAsync(Guid productOwnerId)
        {
            return await _context.ProductOwners.FindAsync(productOwnerId);
        }

        public void Update(ProductOwner productOwner)
        {
            _context.ProductOwners.Update(productOwner);
            _context.SaveChanges();
        }
    }
}
