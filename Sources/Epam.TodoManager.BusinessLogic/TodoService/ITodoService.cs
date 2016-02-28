using System;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public interface ITodoService
    {
        void Rename(int id, string newName);
        void SetDueDate(int id, DateTime dueDate);
        void EditNote(int id, string note);
        void Delete(int id);
        void SetCompletionState(bool isCompleted);
    }
}
