using Desafio.FeedbackService.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio.FeedbackService.Migrations
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<FeedbackServiceContext>();
            context.Database.Migrate();
        }
    }
}
