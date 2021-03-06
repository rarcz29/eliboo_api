using Eliboo.Application.Repositories;
using Eliboo.Application.Services;
using Eliboo.Infrastructure.DataAccess;
using Eliboo.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace Eliboo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Users = new UserRepository(db);
            Books = new BookRepository(db);
            Libraries = new LibraryRepository(db);
            Bookshelves = new BookshelfRepository(db);
            MyList = new ListRepository(db);
        }

        public IUserRepository Users { get; private set; }

        public IBookRepository Books { get; private set; }

        public ILibraryRepository Libraries { get; private set; }

        public IBookshelfRepository Bookshelves { get; private set; }

        public IListRepository MyList { get; private set; }

        public int Commit()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
