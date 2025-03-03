using AutoMapper;
using Desafio.AuthService.Data.DTO;

namespace Desafio.AuthService.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Mapeamento de RegisterUserRequest para User passando o document como UserName
            CreateMap<RegisterUserRequest, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Document));
        }
    }
}
