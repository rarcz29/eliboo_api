using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories
{
    public interface IBookshelfRepository : IRepository<Bookshelf>
    {
        void Remove(string description, int userId);

        Task<int> GetIdAsync(string description, int userId);
    }
}
