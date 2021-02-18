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

        public int GetLibraryIdByUsername(string username)
        {
            return _db.Users
                .Where(u => u.Nickname == username)
                .Select(u => u.Id)
                .FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users
                .Where(u => u.Email == email)
                .FirstOrDefault();
        }
    }
}
