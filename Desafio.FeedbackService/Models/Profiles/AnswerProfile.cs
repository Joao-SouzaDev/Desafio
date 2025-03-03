using AutoMapper;
using Desafio.FeedbackService.Data.DTO;

namespace Desafio.FeedbackService.Models.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<CreateAnswerRequest, Answer>();
            CreateMap<Answer, GetAnswerResponse>();
            CreateMap<GetAnswerResponse, Answer>();
        }
    }
}
