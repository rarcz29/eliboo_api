using Eliboo.Data.Repositories;
using System.Threading.Tasks;

namespace Eliboo.Data.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            Books = new BookRepository(db);
        }

        public IBookRepository Books { get; private set; }

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
