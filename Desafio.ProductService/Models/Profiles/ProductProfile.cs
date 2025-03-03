using AutoMapper;
using Desafio.ProductService.Data.DTO;

namespace Desafio.ProductService.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductResponse>();
            CreateMap<CreateProductRequest, Product>();
        }
    }
}
