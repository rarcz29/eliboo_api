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

        public async Task AddToReaingNow(int userId, int bookId)
        {
            var user = await _db.Users
                .FindAsync(userId);

            var book = await _db.Books.FindAsync(bookId);
            user.CurrentReading = book;
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
                .Include(b => b.Bookshelf)
                .Where(b => _db.Bookshelves.Where(bs => bs.LibraryId == libraryId)
                    .Select(bs => bs.Id).Contains(b.BookshelfId))
                .ToListAsync();
        }

        public async Task<Book> GetReadingNow(int userId)
        {
            return await _db.Books
                .Include(b => b.User.Id == userId)
                .FirstOrDefaultAsync();
        }
    }
}
