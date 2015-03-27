using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Servier.Repository.Interface
{
    /// <summary>
    /// Interface for generic repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(int id);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

    }
}
