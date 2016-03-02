using System;
using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public interface ITodoService
    {
        void Rename(int userId, int listId, int todoId, string newName);
        void EditNote(int listId, int todoId, string note);
        void Delete(Todo item);
        void SetCompletionState(int listId, int todoId, bool isCompleted);
    }
}
