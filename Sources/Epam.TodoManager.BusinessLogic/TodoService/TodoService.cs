using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public class TodoService : ITodoService
    {
        private IRepository<TodoList, int> todoListRepository;

        public void Delete(int listId, int todoId)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(listId));
            }

            Todo todoItem = list.TodoItems.FirstOrDefault(item => item.Id == todoId);

            if (todoItem == null)
            {
                throw new ArgumentException("A specified list doesn't contain todo item with a specified id", nameof(listId));
            }
        }

        public void EditNote(int listId, int todoId, string note)
        {
            throw new NotImplementedException();
        }

        public void Rename(int listId, int todoId, string newName)
        {
            throw new NotImplementedException();
        }

        public void SetCompletionState(int listId, int todoId, bool isCompleted)
        {
            throw new NotImplementedException();
        }

        public void SetDueDate(int listId, int todoId, DateTime dueDate)
        {
            throw new NotImplementedException();
        }
    }
}
