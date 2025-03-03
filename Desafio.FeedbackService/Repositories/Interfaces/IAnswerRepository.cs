using Desafio.FeedbackService.Models;

namespace Desafio.FeedbackService.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
        Task CreateAsync(Answer request);
        Task<Answer?> GetByFeedbackIdAsync(Guid feedbackId);
    }
}
