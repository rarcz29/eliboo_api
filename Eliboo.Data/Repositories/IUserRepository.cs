using Eliboo.Data.Entities;

namespace Eliboo.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
    }
}
