using Desafio.AuthService.Data;
using Microsoft.EntityFrameworkCore;

namespace Desafio.AuthService.Migrations
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AuthServiceContext>();
            context.Database.Migrate();
        }
    }
}
