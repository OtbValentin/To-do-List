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
        TodoList GetTodoList(int userId, int listId);
        void AddTodo(int userId, int listId, string task);
        void RemoveTodo(int userId, int listId, int todoId);
        void RenameList(int userId, int listId, string newName);
        void ShiftTodo(int userId, int listId, int todoId, int index);
        void AddTodoList(int userId, string title);
        void RemoveTodoList(int userId, int listId);
    }
}
