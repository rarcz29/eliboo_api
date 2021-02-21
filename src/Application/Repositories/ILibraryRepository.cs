using Eliboo.Domain.Entities;
using System.Threading.Tasks;

namespace Eliboo.Application.Repositories
{
    public interface ILibraryRepository : IRepository<Library>
    {
        void RemoveUsingToken(string Token);

        Task<int> GetId(string accessToken);

        Task<int> GetNumberOfUsersAsync(int id);
    }
}
