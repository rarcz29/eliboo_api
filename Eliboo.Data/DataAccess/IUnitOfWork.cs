using Eliboo.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Eliboo.Data.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
