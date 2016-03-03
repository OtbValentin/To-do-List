using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public interface ITodoService
    {
        void CompleteTodo(int listCollectionId, int listId, int todoId);
        void MarkTodoAsUncompleted(int listCollectionId, int listId, int todoId);
        void MoveTodoToAnotherList(int listCollectionId, int sourceListId, int todoId, int destinationListId);
        void RenameTodo(int listCollectionId, int listId, int todoId, int newName);
        void SetTodoDueDate(int listCollectionId, int listId, int todoId, DateTime? dueDate);
        void EditTodoNote(int listColectionId, int listId, int todoId, int newNote);
    }
}
