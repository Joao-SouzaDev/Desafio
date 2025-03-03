namespace Desafio.FeedbackService.Data.DTO
{
    public class CreateFeecbackRequest
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Reating { get; set; }
        public string Email { get; set; }

    }
}
