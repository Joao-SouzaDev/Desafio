using Desafio.ProductService.Repositories;
using Desafio.ProductService.Repositories.Interfaces;
using Desafio.ProductService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Desafio.ProductService.Helpers
{
    public static class ServicesHelper
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
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
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductOwnerRepository, ProductOwnerRepository>();
            services.AddScoped<ProductServices>();
            services.AddScoped<ProductOwnerService>();
            services.AddSingleton<MqReceiverServices>();
            services.AddHostedService(provider => provider.GetRequiredService<MqReceiverServices>());
        }
    }
}
