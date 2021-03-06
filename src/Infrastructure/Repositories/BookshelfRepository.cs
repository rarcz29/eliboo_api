using Eliboo.Application.Repositories;
using Eliboo.Domain.Entities;
using Eliboo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliboo.Infrastructure.Repositories
{
    class BookshelfRepository : Repository<Bookshelf>, IBookshelfRepository
    {
        private readonly AppDbContext _db;

        public BookshelfRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Bookshelf>> GetAll(int userId)
        {
            var libraryId = await _db.Users
                .Where(u => u.Id == userId)
                .Select(u => u.LibraryId)
                .FirstOrDefaultAsync();

            return await _db.Bookshelves
                .Where(b => b.LibraryId == libraryId)
                .ToListAsync();
        }

        public async Task<int> GetIdAsync(string description, int userId)
        {
            return await _db.Bookshelves
                .Where(b => b.Description == description
                    && b.LibraryId ==
                    _db.Users.Where(
                    u => u.Id == userId)
                        .Select(u => u.LibraryId)
                        .FirstOrDefault())
                    .Select(b => b.Id)
                .FirstOrDefaultAsync();
        }

        public void Remove(string description, int userId)
        {
            _db.Bookshelves.Remove(
                _db.Bookshelves.Where(
                b => b.Description == description
                && b.LibraryId ==
                _db.Users.Where(
                u => u.Id == userId)
                    .Select(u => u.LibraryId)
                .FirstOrDefault())
            .FirstOrDefault());
        }
    }
}
