using System.Threading.Tasks;

namespace Eliboo.Application.Services
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string email, string password);

        Task<bool> RegisterAsync(string username, string email, string password);

        Task<bool> RegisterAsync(string username, string email, string password, int libraryId);
    }
}
