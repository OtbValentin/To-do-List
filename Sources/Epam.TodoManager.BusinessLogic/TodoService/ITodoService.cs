using Epam.TodoManager.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public interface ITodoService
    {
        void Rename(int id, string newName);
        void SetDueDate(int id, DateTime dueDate);
        void AddNote(int id, string note);
        void Delete(int id);
        void SetCompletionState(bool isCompleted);
    }
}
