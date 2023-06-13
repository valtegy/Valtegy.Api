using Valtegy.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Valtegy.Repository.Context;

namespace Valtegy.Repository.Repositories
{
    public class DataRepository<TEntity> : IDataRepository<TEntity> where TEntity : class, new()
    {
        private readonly ValtegyDbContext _context;
        public DataRepository(ValtegyDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entities must not be null");
            }

            try
            {
                _context.AddRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entities)} could not be updated");
            }
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entities must not be null");
            }

            try
            {
                _context.UpdateRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entities)} could not be updated");
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        //void IDataRepository<TEntity>.Create(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        void IDataRepository<TEntity>.Delete(object id)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IDataRepository<TEntity>.Get()
        {
            throw new NotImplementedException();
        }

        TEntity IDataRepository<TEntity>.Get(object id)
        {
            throw new NotImplementedException();
        }

        void IDataRepository<TEntity>.Update(TEntity dbEntity, TEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
