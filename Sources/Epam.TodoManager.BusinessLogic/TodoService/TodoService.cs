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
        private IUserRepository userRepository;

        public void Delete(Todo todo)
        {
            User user = userRepository.Find(todo.List.User.Id);

            if (user == null)
            {
                throw new ArgumentException("This todo item is not assigned to a user");
            }

            TodoList list = user.TodoLists.FirstOrDefault(l => l.Id == todo.List.Id);

            if (list == null)
            {
                throw new ArgumentException("This todo item is not assigned to a list");
            }

            list.RemoveTodo(todo.Id);
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
    }
}
