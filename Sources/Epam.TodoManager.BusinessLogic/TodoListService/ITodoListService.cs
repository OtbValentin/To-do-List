using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.BusinessLogic.TodoListService
{
    public interface ITodoListService
    {
        void CreateList(int userId, string title);
        void AddTodo(int listId, string todoText);
        TodoList Find(int id);
        void Reorder(int listId, int todoId, int index);
        void MoveTodoToAnotherList(int todoId, int newListId);
        void Delete(int listId);
        void Rename(int listId, string newName);
    }
}
