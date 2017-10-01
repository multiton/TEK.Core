namespace TEK.Core.Entity
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; set; }
    }
}