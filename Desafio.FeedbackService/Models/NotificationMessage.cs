namespace Desafio.FeedbackService.Models
{
    public class NotificationMessage
    {
        public string Queue { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
