using Eliboo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Application.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllFromLibraryAsync(int libraryId);
    }
}
