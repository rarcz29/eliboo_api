using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories
{
    public interface ILibraryRepository : IRepository<Library>
    {
        void RemoveUsingToken(string Token);

        Task<int> GetId(string accessToken);

        Task<int> GetNumberOfUsersAsync(int id);
    }
}
