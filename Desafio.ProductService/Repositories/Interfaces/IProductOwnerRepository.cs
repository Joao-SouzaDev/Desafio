using Desafio.ProductService.Models;

namespace Desafio.ProductService.Repositories.Interfaces
{
    public interface IProductOwnerRepository
    {
        void Add(ProductOwner productOwner);
        IEnumerable<ProductOwner> GetAll();
        Task<ProductOwner?> GetByIdAsync(Guid productOwnerId);
        void Update(ProductOwner productOwner);
        void Delete(ProductOwner productOwner);
    }
}
