namespace DomainModel
{
    public interface IUnique<TKey>
    {
         TKey Id { get; }
    }
}
