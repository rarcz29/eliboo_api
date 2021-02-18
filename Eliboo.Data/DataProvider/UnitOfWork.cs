using Eliboo.Data.DataAccess;
using Eliboo.Data.Repositories;
using System.Threading.Tasks;

namespace Eliboo.Data.DataProvider
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
        }

        public IUserRepository Users { get; private set; }

        public IBookRepository Books { get; private set; }

        public ILibraryRepository Libraries { get; private set; }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
