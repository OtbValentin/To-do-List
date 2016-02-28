using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public class TodoService : ITodoService
    {

        public void EditNote(int id, string note)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Rename(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public void SetCompletionState(bool isCompleted)
        {
            throw new NotImplementedException();
        }

        public void SetDueDate(int id, DateTime dueDate)
        {
            throw new NotImplementedException();
        }
    }
}
