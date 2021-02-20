using Eliboo.Data.DataAccess;
using Eliboo.Data.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Eliboo.Api.Installers
{
    public class DataAccessInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
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
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}
