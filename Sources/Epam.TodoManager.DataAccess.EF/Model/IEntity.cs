namespace Epam.TodoManager.DataAccess.EF.Model
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
