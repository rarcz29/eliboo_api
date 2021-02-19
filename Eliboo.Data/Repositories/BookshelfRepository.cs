using Eliboo.Data.DataAccess;
using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;

namespace Eliboo.Data.Repositories
{
    class BookshelfRepository : Repository<Bookshelf>, IBookshelfRepository
    {
        private readonly AppDbContext _db;

        public BookshelfRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
