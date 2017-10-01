namespace TEK.Core.Entity
{
    public interface ICreatable<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        void AddRange(TEntity entity);
    }
}