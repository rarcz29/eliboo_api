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

        public async Task AddToReadingNowAsync(int userId, int bookId)
        {
            var user = await _db.Users.FindAsync(userId);
            var book = await _db.Books.FindAsync(bookId);

            if (book != null)
            {
                user.CurrentReading = book;
            }
        }

        public async Task<IEnumerable<Book>> FindBooksAsync(Book pattern, int libraryId)
        {
            return await _db.Books
                .Include(book => book.Bookshelf)
                .Where(b => (pattern.Title != null && EF.Functions.Like(b.Title, $"%{pattern.Title}%"))
                    || (pattern.Author != null && EF.Functions.Like(b.Author, $"%{pattern.Author}%"))
                    || (pattern.Genre != null && EF.Functions.Like(b.Genre, $"%{pattern.Genre}%")))
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

        public async Task<Book> GetReadingNowAsync(int userId)
        {
            try
            {
                return await _db.Books
                    .Include(b => b.User)
                    .Where(b => b.User.Id == userId)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task RemoveReadingNowAsync(int userId)
        {
            var user = await _db.Users.FindAsync(userId);
            user.CurrentReading = null;
            user.CurrentReadingId = null;
        }
    }
}
