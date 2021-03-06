using Eliboo.Application.Services;
using Eliboo.Infrastructure.DataAccess;
using Eliboo.Infrastructure.Services;
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
                    .UseNpgsql(configuration.GetConnectionString("Default"))
                    .UseLoggerFactory(
                        LoggerFactory
                            .Create(builder => builder.AddConsole()
                            .AddFilter((category, level)
                                => category == DbLoggerCategory.Database.Command.Name
                                && level == LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .UseSnakeCaseNamingConvention();
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            return services;
        }
    }
}
