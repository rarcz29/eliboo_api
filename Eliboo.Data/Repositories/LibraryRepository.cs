using Eliboo.Data.DataAccess;
using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;

namespace Eliboo.Data.Repositories
{
    class LibraryRepository : Repository<Library>, ILibraryRepository
    {
        private readonly AppDbContext _db;

        public LibraryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
