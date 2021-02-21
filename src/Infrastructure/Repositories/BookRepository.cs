using Eliboo.Application.Repositories;
using Eliboo.Domain.Entities;
using Eliboo.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliboo.Infrastructure.Repositories
{
    class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Book>> GetAllFromLibraryAsync(int libraryId)
        {
            return await _db.Books
                .Where(b => b.BookshelfId == _db.Bookshelves.Where(bs => bs.LibraryId == libraryId)
                    .Select(bs => bs.Id).FirstOrDefault())
                .ToListAsync();
        }
    }
}
