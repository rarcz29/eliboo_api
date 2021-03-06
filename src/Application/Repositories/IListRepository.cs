using Eliboo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Application.Repositories
{
    public interface IListRepository
    {
        Task AddBooksToTheListAsync(int userId, IEnumerable<int> bookIds);

        Task RemoveBooksFromListAsync(int userId, IEnumerable<int> bookIds);

        Task<IEnumerable<Book>> GetAllBooksFromListAsync(int userId);
    }
}
