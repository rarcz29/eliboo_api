using Eliboo.Application.Repositories;
using Eliboo.Domain.Entities;
using Eliboo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Book>> FindBooksAsync(Book pattern, int libraryId)
        {
            return await _db.Books
                .Include(book => book.Bookshelf)
                .Where(b => (EF.Functions.Like(b.Title, $"%{pattern.Title}%")
                    || EF.Functions.Like(b.Author, $"%{pattern.Author}%")
                    || EF.Functions.Like(b.Genre, $"%{pattern.Genre}%")
                    || EF.Functions.Like(b.Bookshelf.Description, $"%{pattern.Bookshelf}%"))
                    && b.Bookshelf.LibraryId == libraryId)
                .ToListAsync();
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
