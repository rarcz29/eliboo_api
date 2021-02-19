using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

        Task<int> GetLibraryIdAsync(int userId);
    }
}
