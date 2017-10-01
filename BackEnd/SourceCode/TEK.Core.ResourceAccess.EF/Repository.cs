﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using TEK.Core.Entity;

namespace TEK.Core.ResourceAccess.EF
{
    public class Repository<TEntity> where TEntity : BaseEntity, new()  //: IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DbContext dbContext;
        private readonly DbSet<TEntity> entitySet;

        public Repository(DbContext dbContext)
        {
            // Requires.ArgumentNotNull(dbContext, "dbContext");

            this.dbContext = dbContext;
            this.entitySet = dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            return this.entitySet.Add(entity).Entity;
        }

        public BaseEntity Attach(BaseEntity entity)
        {
            if (entity == null) return null;

            return this.dbContext.Attach(entity).Entity;
        }

        public virtual TEntity Delete(params object[] keyValues)
        {
            if (keyValues == null || keyValues.Length == 0) return null;

            var entityToDelete = this.entitySet.Find(keyValues);

            if (entityToDelete == null) return null;

            return this.Delete(entityToDelete);
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null) return null;

            if (this.dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.entitySet.Attach(entity);
            }

            return this.entitySet.Remove(entity).Entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Get(predicate, null);
        }

        public TEntity Get(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query = this.entitySet;

            if (include != null && include.Any())
            {
                foreach (var includeExpression in include)
                {
                    if (includeExpression != null)
                    {
                        query = query.Include(includeExpression);
                    }
                }
            }

            return query.FirstOrDefault(predicate);
        }

        public TEntity Get(params object[] keyValues)
        {
            var entity = this.entitySet.Find(keyValues);
            return entity;
        }

        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return this.Find(predicate, orderBy, (Expression<Func<TEntity, object>>)null);
        }

        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query = this.entitySet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (include != null && include.Any())
            {
                foreach (var includeExpression in include)
                {
                    if (include != null && include[0] != null)
                    {
                        query = query.Include(includeExpression);
                    }
                }
            }

            return query;       // ??? .ToList() !!! ???
        }

        public TEntity Update(TEntity entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Set<TValue, T>(object entity, Expression<Func<T>> propertyExpression, TValue propertyValue)
        {
            //Requires.ArgumentNotNull(propertyExpression, "propertyExpression");

            var propertyName = $"{((MemberExpression)propertyExpression.Body).Member.Name}Id";

            this.dbContext.Entry(entity).Property(propertyName).CurrentValue = propertyValue;
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        // Re-think asynch operations
        //
        //public Task<int> SaveChangesAsync()
        //{
        //    return this.dbContext.SaveChangesAsync();
        //}
    }
}