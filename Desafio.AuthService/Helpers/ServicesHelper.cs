using Desafio.AuthService.Configurations;
using Desafio.AuthService.Data;
using Desafio.AuthService.Models;
using Desafio.AuthService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Desafio.AuthService.Helpers
{
    public static class ServicesHelper
    {
        // Método de extensão para adicionar os serviços ao projeto
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("Jwt").Get<JwtConfig>();
            if (jwtConfig == null)
            {
                throw new ArgumentNullException("JwtConfig");
            }
            // Configuração para a autenticação JWT ao projeto
            services.AddIdentity<User, UserAccess>()
                .AddEntityFrameworkStores<AuthServiceContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
                };
            });

            services.AddTransient<UserServices>();
            services.AddTransient<TokenService>();
            services.AddSingleton<MqServices>();
        }
    }
}
