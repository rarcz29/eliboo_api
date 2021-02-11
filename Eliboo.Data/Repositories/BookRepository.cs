using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Eliboo.Data.Repositories
{
    class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbContext db) : base(db) { }
    }
}
