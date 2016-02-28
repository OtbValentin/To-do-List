using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.BusinessLogic.TodoListService
{
    public class TodoListService : ITodoListService
    {
        public void AddTodo(int listId, string todoText)
        {
            throw new NotImplementedException();
        }

        public void CreateList(int userId, string title)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TodoList Find(int id)
        {
            throw new NotImplementedException();
        }

        public void SwapListItems(int listId, int firstItemId, int secondItemId)
        {
            throw new NotImplementedException();
        }
    }
}
