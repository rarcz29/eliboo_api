using Eliboo.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Eliboo.Data.DataProvider
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IBookRepository Books { get; }

        ILibraryRepository Libraries { get; }

        IBookshelfRepository Bookshelves { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
