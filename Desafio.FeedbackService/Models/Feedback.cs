namespace Desafio.FeedbackService.Models
{
    public class Feedback
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Guid ProductId { get; private set; }
        public int Reating { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Answer Answer { get; private set; }
        public Feedback()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
