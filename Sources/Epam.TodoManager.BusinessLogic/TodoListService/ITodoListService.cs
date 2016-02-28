using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.BusinessLogic.TodoListService
{
    public interface ITodoListService
    {
        void CreateList(int userId, string title);
        void AddTodo(int listId, string todoText);
        TodoList Find(int id);
        void SwapListItems(int listId, int firstItemId, int secondItemId);
        void Delete(int id);
    }
}
