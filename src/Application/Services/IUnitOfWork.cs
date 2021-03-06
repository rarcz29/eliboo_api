using Eliboo.Application.Repositories;
using System;
using System.Threading.Tasks;

namespace Eliboo.Application.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IBookRepository Books { get; }

        ILibraryRepository Libraries { get; }

        IBookshelfRepository Bookshelves { get; }

        IListRepository MyList { get; }

        int Commit();

        Task<int> CommitAsync();
    }
}
