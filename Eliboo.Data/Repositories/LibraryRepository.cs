using Eliboo.Data.DataAccess;
using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories
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

        public void RemoveUsingToken(string Token)
        {
            //_db.Libraries.Remove
        }
    }
}
