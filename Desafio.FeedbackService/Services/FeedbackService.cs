using Desafio.FeedbackService.Models;
using Desafio.FeedbackService.Repositories.Interfaces;

namespace Desafio.FeedbackService.Services
{
    public class FeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly MqServices _mqServices;
        public FeedbackService(IFeedbackRepository feedbackRepository, MqServices mqServices)
        {
            _feedbackRepository = feedbackRepository;
            _mqServices = mqServices;
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
                await _mqServices.SendMessageAsync(new NotificationMessage { Queue = string.Empty, Body = "Obrigado pelo feedback, essa situação foi enviada para o criado do produto. Assim que possível você será respondido(a)", To = request.Email,Subject= "Feedback" });
                
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
        public async Task<Feedback?> GetFeedbackByIdAsync(Guid feedbackId)
        {
            return await _feedbackRepository.GetByIdAsync(feedbackId);
        }
        public async Task<IEnumerable<Feedback?>> GetFeedbacksByProductIdAsync(Guid productId)
        {
            return (await _feedbackRepository.GetByProductIdAsync(productId)).ToList();
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
