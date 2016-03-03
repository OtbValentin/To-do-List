using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.BusinessLogic.TodoListService
{
    public interface ITodoListService
    {
        IEnumerable<TodoList> GetTodoLists(int userId);
        void AddTodo(int listCollectionId, int listId, string task);
        void RemoveTodo(int listCollectionId, int listId, int todoId);
        void RenameList(int listCollectionId, int listId, string newName);
        void ShiftTodo(int listCollectionId, int listId, int todoId, int index);

        void AddTodoList(int listCollectionId);
        void RemoveTodoList(int listCollectionId, int listId);
    }
}
