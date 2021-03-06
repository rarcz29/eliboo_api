using Eliboo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Application.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllFromLibraryAsync(int libraryId);

        Task<IEnumerable<Book>> FindBooksAsync(Book pattern, int libraryId);

        Task<Book> GetReadingNowAsync(int userId);

        Task AddToReadingNowAsync(int userId, int bookId);

        Task RemoveReadingNowAsync(int userId);
    }
}
