namespace Desafio.FeedbackService.Data.DTO
{
    public class GetAnswerResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
