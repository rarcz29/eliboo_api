using Eliboo.Data.Entities;
using Eliboo.Data.GenericRepository;

namespace Eliboo.Data.Repositories
{
    public interface ILibraryRepository : IRepository<Library>
    {
        void RemoveUsingToken(string Token);
    }
}
