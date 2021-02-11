using Eliboo.Data.DataAccess;
using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using System.Linq;

namespace Eliboo.Data.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users
                .Where(u => u.Email == email)
                .FirstOrDefault();
        }
    }
}
