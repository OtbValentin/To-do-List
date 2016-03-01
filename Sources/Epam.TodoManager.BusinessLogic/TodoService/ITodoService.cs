using System;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public interface ITodoService
    {
        void Rename(int listId, int todoId, string newName);
        void EditNote(int listId, int todoId, string note);
        void Delete(int listId, int todoId);
        void SetCompletionState(int listId, int todoId, bool isCompleted);
    }
}
