using Desafio.FeedbackService.Data;
using Desafio.FeedbackService.Models;
using Desafio.FeedbackService.Repositories.Interfaces;

namespace Desafio.FeedbackService.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly FeedbackServiceContext _context;
        public AnswerRepository(FeedbackServiceContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Answer request)
        {
            _context.Answers.Add(request);
            await _context.SaveChangesAsync();
        }

        public Task<Answer?> GetByFeedbackIdAsync(Guid feedbackId)
        {
            return Task.FromResult(_context.Answers.Where(a => a.FeedbackId == feedbackId).FirstOrDefault());
        }
    }
}
