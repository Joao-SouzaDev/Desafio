using Desafio.FeedbackService.Data;
using Desafio.FeedbackService.Models;
using Desafio.FeedbackService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.FeedbackService.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackServiceContext _context;
        public FeedbackRepository(FeedbackServiceContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Feedback request)
        {
            _context.Feedbacks.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public Task<Feedback?> GetByIdAsync(Guid id)
        {
            return _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Feedback request)
        {
            _context.Feedbacks.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
