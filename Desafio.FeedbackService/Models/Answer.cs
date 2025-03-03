namespace Desafio.FeedbackService.Models
{
    public class Answer
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Guid FeedbackId { get; private set; }
        public Guid ProductOwnerId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Feedback Feedback { get; private set; }
        public Answer()
        {
            Id = new Guid();
        }
    }
}
