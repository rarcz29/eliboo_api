using System.Threading.Tasks;

namespace Eliboo.Api.Services
{
    public interface IIdentityManager
    {
        string Authenticate(string email, string password);

        void Register(string username, string email, string password);
    }
}
