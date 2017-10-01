using System.Collections.Generic;

namespace TEK.Core.ResourceAccess.Contract
{
    public interface IDeletable<TEntity> where TEntity : class
    {
        TEntity Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}