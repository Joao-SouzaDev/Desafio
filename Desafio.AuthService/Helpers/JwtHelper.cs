using Desafio.AuthService.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Desafio.AuthService.Helpers
{
    // Essa classe é responsável por adicionar a autenticação JWT ao projeto
    public static class JwtHelper
    {
        // Método de extensão para adicionar a autenticação JWT ao projeto
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            // Recupera as configurações do JWT
            var jwtConfig = configuration.GetSection("Jwt").Get<JwtConfig>();
            if(jwtConfig == null)
            {
                throw new ArgumentNullException("JwtConfig");
            }
            var key = Encoding.ASCII.GetBytes(jwtConfig.Key);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtConfig.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}