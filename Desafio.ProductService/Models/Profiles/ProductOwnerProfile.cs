using AutoMapper;
using Desafio.ProductService.Data.DTO;

namespace Desafio.ProductService.Models.Profiles
{
    public class ProductOwnerProfile : Profile
    {
        public ProductOwnerProfile()
        {
            CreateMap<ProductOwner, GetProductOwnerResponse>();
        }
    }
}
