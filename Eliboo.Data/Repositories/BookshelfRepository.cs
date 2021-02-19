using Eliboo.Data.DataAccess;
using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using System.Linq;

namespace Eliboo.Data.Repositories
{
    class BookshelfRepository : Repository<Bookshelf>, IBookshelfRepository
    {
        private readonly AppDbContext _db;

        public BookshelfRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Remove(string description, int userId)
        {
            _db.Bookshelves.Remove(
                _db.Bookshelves.Where(
                    b => b.Description == description
                        && b.LibraryId == (
                            _db.Users.Where(
                                u => u.Id == userId)
                                    .Select(u => u.LibraryId))
                            .FirstOrDefault())
                .FirstOrDefault());
        }
    }
}
