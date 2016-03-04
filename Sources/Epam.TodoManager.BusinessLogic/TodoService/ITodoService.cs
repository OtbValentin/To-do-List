using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public interface ITodoService
    {
        void CompleteTodo(int userId, int listId, int todoId);
        void MarkTodoAsUncompleted(int userId, int listId, int todoId);
        void MoveTodoToAnotherList(int userId, int sourceListId, int todoId, int destinationListId);
        void RenameTodo(int userId, int listId, int todoId, string newName);
        void SetTodoDueDate(int userId, int listId, int todoId, DateTime? dueDate);
        void EditTodoNote(int userId, int listId, int todoId, string newNote);
    }
}
