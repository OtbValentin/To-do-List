using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.BusinessLogic.TodoListService
{
    public interface ITodoListService
    {
        TodoList Find(int id);
        void AddTodo(int listId, string todoText);
        void Reorder(int listId, int todoId, int index);
        void MoveTodoToAnotherList(int listId, int newListId, int todoId);
        void Delete(int listId);
        void Rename(int listId, string newTitle);
    }
}
