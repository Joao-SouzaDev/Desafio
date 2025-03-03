using Desafio.FeedbackService.Models;

namespace Desafio.FeedbackService.Data.DTO
{
    public class GetFeedbackResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Reating { get; set; }
        public DateTime CreatedAt { get; set; }

        public GetAnswerResponse Answers { get; set; }
    }
}
