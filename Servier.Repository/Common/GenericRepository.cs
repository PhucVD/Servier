using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Servier.Repository.Interface;

namespace Servier.Repository.Common
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void DeleteById(int id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public TEntity GetById(int id)
        {
            TEntity entity = dbSet.Find(id);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Where(filter).AsEnumerable<TEntity>();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
