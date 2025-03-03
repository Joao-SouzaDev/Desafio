using Desafio.FeedbackService.Models;
using Desafio.FeedbackService.Repositories.Interfaces;

namespace Desafio.FeedbackService.Services
{
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public async Task CreateAnswerAsync(Answer answer)
        {
            await _answerRepository.CreateAsync(answer);
        }
        public async Task<Answer?> GetAnswersAsync(Guid feedbackId)
        {
            return await _answerRepository.GetByFeedbackIdAsync(feedbackId);
        }
    }
}
