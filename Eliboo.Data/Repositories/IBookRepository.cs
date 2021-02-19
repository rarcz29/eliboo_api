using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllFromLibraryAsync(int libraryId);
    }
}
