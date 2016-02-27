namespace Epam.TodoManager.DomainModel
{
    public interface IUnique<TKey>
    {
         TKey Id { get; }
    }
}
