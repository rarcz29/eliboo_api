using Eliboo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Application.Repositories
{
    public interface IBookshelfRepository : IRepository<Bookshelf>
    {
        void Remove(string description, int userId);

        Task<int> GetIdAsync(string description, int userId);

        Task<IEnumerable<Bookshelf>> GetAll(int userId);
    }
}
