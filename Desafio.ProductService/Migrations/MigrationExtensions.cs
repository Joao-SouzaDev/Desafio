using Desafio.ProductService.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio.ProductService.Migrations
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ProductServiceContext>();
            context.Database.Migrate();
        }
    }
}
