using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using GameStore.Domain.EMDB.Repositories.Interfaces;

namespace GameStore.Domain.EMDB.Repositories.Classes
{
    public class RepositoryBase<TEntity> : IReporitoryBase<TEntity> where TEntity : class 
    {
        protected readonly DbContext m_context;
        protected readonly IQueryable<TEntity> m_entities;

        public RepositoryBase(DbContext context)
        {
            m_context = context;
            m_entities = m_context.Set<TEntity>();
        }

        public TEntity Get(int Id)
        {
            return m_context?.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return m_entities?.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return m_entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return m_entities.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            if (entity == null) return;
            m_context.Set<TEntity>().Add(entity);
        }

        public void AddOrUpdate(TEntity entity)
        {
            if (entity == null) return;
            m_context.Set<TEntity>().AddOrUpdate(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) return;
            m_context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null) return;
            m_context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) return;
            m_context.Set<TEntity>().RemoveRange(entities);
        }

        public int SaveChanges()
        {
          return  m_context.SaveChanges();
        }
    }
}
