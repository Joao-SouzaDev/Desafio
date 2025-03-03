using Desafio.FeedbackService.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio.FeedbackService.Helpers
{
    public static class ContextHelper
    {
        public static void AddDataContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FeedbackServiceContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
