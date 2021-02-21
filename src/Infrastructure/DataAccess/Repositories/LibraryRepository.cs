using Eliboo.Application.Repositories;
using Eliboo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Eliboo.Infrastructure.DataAccess.Repositories
{
    class LibraryRepository : Repository<Library>, ILibraryRepository
    {
        private readonly AppDbContext _db;

        public LibraryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<int> GetId(string accessToken)
        {
            return await _db.Libraries
                .Where(l => l.AccessToken == accessToken)
                .Select(l => l.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetNumberOfUsersAsync(int id)
        {
            return await _db.Users
                .Where(u => u.LibraryId == id)
                .GroupBy(u => u.LibraryId)
                .Select(g => g.Count())
                .FirstOrDefaultAsync();
        }

        public void RemoveUsingToken(string Token)
        {
            throw new System.NotImplementedException();
        }
    }
}
