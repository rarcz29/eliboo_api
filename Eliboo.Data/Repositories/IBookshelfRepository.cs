using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;

namespace Eliboo.Data.Repositories
{
    public interface IBookshelfRepository : IRepository<Bookshelf>
    {
        void Remove(string description, int userId);
    }
}
