using Eliboo.Api.Services;
using Eliboo.Application.Options;
using Eliboo.Application.Services;
using Eliboo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Eliboo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseNpgsql(configuration.GetConnectionString("Develop"))
                    .UseLoggerFactory(
                        LoggerFactory
                            .Create(builder => builder.AddConsole()
                            .AddFilter((category, level)
                                => category == DbLoggerCategory.Database.Command.Name
                                && level == LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .UseSnakeCaseNamingConvention();
            });
            var jwtOptions = new JwtOptions();
            configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);
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
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(jwtOptions.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSingleton<IAuthService, AuthService>();
            return services;
        }
    }
}
