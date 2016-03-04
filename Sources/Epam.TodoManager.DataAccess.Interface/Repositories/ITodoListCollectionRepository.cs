using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.DataAccess.Interface.Repositories
{
    public interface ITodoListCollectionRepository : IRepository<TodoListCollection, int>
    {
        TodoListCollection GetUserLists(int userId);
    }
}
