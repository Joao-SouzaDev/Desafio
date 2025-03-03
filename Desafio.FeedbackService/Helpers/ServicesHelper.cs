using Desafio.FeedbackService.Repositories;
using Desafio.FeedbackService.Repositories.Interfaces;

namespace Desafio.FeedbackService.Helpers
{
    public static class ServicesHelper
    {
        // Método de extensão para adicionar os serviços ao projeto
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<Services.FeedbackService>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<Services.AnswerService>();
        }
    }
}
