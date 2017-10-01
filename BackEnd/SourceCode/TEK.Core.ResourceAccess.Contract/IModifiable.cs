using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using TEK.Core.Entity;

namespace TEK.Core.ResourceAccess.Contract
{
    public interface IModifiable<TEntity> where TEntity : class
    {
        BaseEntity Attach(BaseEntity entity);

        ICollection<TEntity> Upsert(TEntity[] entities);

        void Set<TValue, T>(object entity, Expression<Func<T>> propertyExpression, TValue propertyValue);
    }
}