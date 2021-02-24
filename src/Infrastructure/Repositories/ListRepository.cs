using Eliboo.Application.Repositories;
using Eliboo.Domain.Entities;
using Eliboo.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliboo.Infrastructure.Repositories
{
    class ListRepository : IListRepository
    {
        private readonly AppDbContext _db;

        public ListRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddBooksToTheListAsync(int userId, IEnumerable<int> bookIds)
        {
            var user = await _db.Users
                .Include(u => u.Books)
                .SingleAsync(u => u.Id == userId);

            var existingBooks = await _db.Books
                .Where(b => bookIds.Contains(b.Id))
                .ToListAsync();

            existingBooks.ForEach(b => user.Books.Add(b));
        }

        public async Task<IEnumerable<Book>> GetAllBooksFromListAsync(int userId)
        {
            return await _db.Users
                .Include(u => u.Books)
                .Where(u => u.Id == userId)
                .Select(u => u.Books)
                .FirstOrDefaultAsync();
        }
    }
}
