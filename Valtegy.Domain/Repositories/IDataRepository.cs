using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Valtegy.Domain.Repositories
{
    public interface IDataRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task AddRangeAsync(List<TEntity> entities);

        Task UpdateRangeAsync(List<TEntity> entities);

        IDbContextTransaction BeginTransaction();
        //Task<TEntity> Create(TEntity entity);
        void Delete(object id);
        IQueryable<TEntity> Get();
        TEntity Get(object id);
        void Update(TEntity dbEntity, TEntity model);
    }
}
