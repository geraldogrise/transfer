using BR.ITAU.TRANSFER.API.Domain.Aggregates.Core;
using BR.ITAU.TRANSFER.API.Domain.Interfaces;
using BR.ITAU.TRANSFER.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BR.ITAU.TRANSFER.Infra.Data.Core.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityCore<TEntity>
    {
        protected DatabaseContext _context;
        protected DbSet<TEntity> _dbSet;

        protected Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entity)
        {
            _dbSet.AddRange(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _dbSet.Add(entity);
            }
        }

        public TEntity GetById(params object[] ids)
        {
            return _dbSet.Find(ids);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _dbSet.Update(entity);
            }
        }

        public void Update(TEntity current, TEntity updated)
        {
            _context.Entry(current).CurrentValues.SetValues(updated);
        }

        public void Remove(params object[] ids)
        {
            _context.Remove(GetById(ids));
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public void RemoveRange(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
