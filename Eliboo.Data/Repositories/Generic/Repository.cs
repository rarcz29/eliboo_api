using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliboo.Data.Repositories.Generic
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _db;

        public Repository(DbContext db)
        {
            _db = db;
        }

        #region Sync operations

        public TEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Async operations

        public async Task<TEntity> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllGetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGetAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRangeGetAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public async Task InsertGetAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task InsertRangeGetAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
