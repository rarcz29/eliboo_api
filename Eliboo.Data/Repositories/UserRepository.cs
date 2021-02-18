using Eliboo.Data.DataAccess;
using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _db.Users
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}
