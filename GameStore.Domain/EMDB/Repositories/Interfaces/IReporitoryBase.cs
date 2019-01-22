using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameStore.Domain.EMDB.Repositories.Interfaces
{
    /// <summary>
    /// Представляет базовый интерфейс паттерна репозиторий для работы с Entities
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IReporitoryBase<TEntity> where TEntity : class
    {
        TEntity Get(int Id);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        
        //сохранить изменения в БД
        int SaveChanges();
    }
}