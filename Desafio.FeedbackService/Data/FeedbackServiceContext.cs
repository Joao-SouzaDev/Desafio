using Desafio.FeedbackService.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.FeedbackService.Data
{
    public class FeedbackServiceContext : DbContext
    {
        public FeedbackServiceContext(DbContextOptions<FeedbackServiceContext> options) : base(options)
        {
        }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Feedback>().HasOne(Feedback => Feedback.Answer).WithOne(Answer => Answer.Feedback).HasForeignKey<Answer>(Answer => Answer.FeedbackId);
        }
    }
}
