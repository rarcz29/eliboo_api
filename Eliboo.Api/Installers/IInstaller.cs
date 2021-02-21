using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliboo.Api.Installers
{
    interface IInstaller2
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
