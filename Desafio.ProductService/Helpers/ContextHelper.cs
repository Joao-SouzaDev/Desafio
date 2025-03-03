using Desafio.ProductService.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio.ProductService.Helpers
{
    public static class ContextHelper
    {
        public static void AddDataContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductServiceContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

    }
}
