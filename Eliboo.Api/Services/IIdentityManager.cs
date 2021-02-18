using System.Threading.Tasks;

namespace Eliboo.Api.Services
{
    public interface IIdentityManager
    {
        Task<string> AuthenticateAsync(string email, string password);

        Task RegisterAsync(string username, string email, string password);
    }
}
