using Desafio.FeedbackService.Models;
using Desafio.FeedbackService.Repositories.Interfaces;

namespace Desafio.FeedbackService.Services
{
    public class FeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task CreateFeedbackAsync(Feedback request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                await _feedbackRepository.CreateAsync(request);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _feedbackRepository.GetAllAsync();
        }
        public async Task<Feedback> GetFeedbackByIdAsync(Guid feedbackId)
        {
            return await _feedbackRepository.GetByIdAsync(feedbackId);
        }
        public async Task UpdateFeedbackAsync(Feedback request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                var feedback = await GetFeedbackByIdAsync(request.Id);
                if(feedback == null)
                {
                    throw new ArgumentNullException(nameof(feedback));
                }
                await _feedbackRepository.UpdateAsync(request);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task DeleteFeedbackAsync(Guid feedbackId)
        {
            var feedback = await GetFeedbackByIdAsync(feedbackId);
            if (feedback == null)
            {
                throw new ArgumentNullException(nameof(feedback));
            }
            await _feedbackRepository.DeleteAsync(feedback);
        }
    }
}
