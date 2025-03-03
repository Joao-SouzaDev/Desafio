using Desafio.FeedbackService.Models;

namespace Desafio.FeedbackService.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<Feedback?> GetByIdAsync(Guid id);
        Task<IEnumerable<Feedback>> GetByProductIdAsync(Guid id);
        Task CreateAsync(Feedback request);
        Task UpdateAsync(Feedback request);
        Task DeleteAsync(Feedback feedback);
    }
}
