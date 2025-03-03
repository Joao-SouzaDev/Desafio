using AutoMapper;
using Desafio.FeedbackService.Data.DTO;

namespace Desafio.FeedbackService.Models.Profiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<Feedback, GetFeedbackResponse>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answer));
            CreateMap<CreateFeecbackRequest, Feedback>();
        }
    }
}
