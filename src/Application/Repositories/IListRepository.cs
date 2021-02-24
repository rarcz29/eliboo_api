using Eliboo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Application.Repositories
{
    public interface IListRepository
    {
        Task AddBooksToTheListAsync(int userId, IEnumerable<int> bookids);

        Task<IEnumerable<Book>> GetAllBooksFromListAsync(int userId);
    }
}
