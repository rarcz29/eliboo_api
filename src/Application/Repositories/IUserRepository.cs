using Eliboo.Domain.Entities;
using System.Threading.Tasks;

namespace Eliboo.Application.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

        Task<int> GetLibraryIdAsync(int userId);
    }
}
