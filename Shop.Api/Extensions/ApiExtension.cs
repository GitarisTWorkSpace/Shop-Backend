using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Services;
using Shop.Core.Stores;
using Shop.Data.Repositories;
using Shop.Infrastructure.Email.Service;
using Shop.Infrastructure.JWT;

namespace Shop.Api.Extensions
{
    public static class ApiExtension
    { 

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<RegistrationService>();
            services.AddScoped<LoginService>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserStore, UserRepository>();
            services.AddScoped<ILoginCodeStore, LoginCodeRepository>();

            return services;
        }

        public static IServiceCollection RegisterInfrastructures(this IServiceCollection services)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddScoped<IEmailService, EmailService>();

            return services;
        }

        public static void AddApiAuthentication(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var jwtOptions = serviceProvider.GetRequiredService<IOptions<JwtOptions>>().Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {                  
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["favourite-displace"];
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                };

            });

            services.AddAuthorization();
        }
    }
}
