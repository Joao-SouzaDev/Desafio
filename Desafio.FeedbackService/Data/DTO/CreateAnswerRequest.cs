namespace Desafio.FeedbackService.Data.DTO
{
    public class CreateAnswerRequest
    {
        public Guid FeedbackId { get; set; }
        public string Description { get; set; }
        public Guid ProductOwnerId { get; set; }
    }
}
