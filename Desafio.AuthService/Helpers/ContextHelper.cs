using Desafio.AuthService.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio.AuthService.Helpers
{
    public static class ContextHelper
    {
        public static void AddDataContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthServiceContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
