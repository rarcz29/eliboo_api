using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        void Delete(Guid id);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);

        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllGetAsync();
        Task DeleteGetAsync(Guid id);
        Task UpdateGetAsync(TEntity entity);
        Task UpdateRangeGetAsync(IEnumerable<TEntity> entities);
        Task InsertGetAsync(TEntity entity);
        Task InsertRangeGetAsync(IEnumerable<TEntity> entities);
    }
}
