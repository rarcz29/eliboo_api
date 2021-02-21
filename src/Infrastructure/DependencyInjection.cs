using Eliboo.Api.Services;
using Eliboo.Application.Services;
using Eliboo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddSingleton<IAuthService, AuthService>();
            return services;
        }
    }
}
