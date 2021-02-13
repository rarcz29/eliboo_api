using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;

namespace Eliboo.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
