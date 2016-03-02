using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class User : IUnique<int>
    {
        public int Id { get; private set; }
        
        public UserProfile Profile { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public IEnumerable<TodoList> TodoLists
        {
            get { return todoLists; }
        }

        private List<TodoList> todoLists;

        public User(int id, string email, string passwordHash, UserProfile profile, IEnumerable<TodoList> todoLists)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            if (todoLists == null)
            {
                throw new ArgumentNullException(nameof(todoLists));
            }

            Id = id;
            Email = email;
            PasswordHash = passwordHash;
            Profile = profile;
            this.todoLists = todoLists.ToList();
        }

        public void AddTodoList(string title)
        {
            todoLists.Add(new TodoList(Id, this, title, null, new List<Todo>()));
        }

        public void RemoveTodoList(int listId)
        {
            TodoList list = todoLists.FirstOrDefault(item => item.Id == listId);

            if (list == null)
            {
                throw new ArgumentException("A list doesn't contain a todo item with the specified id", nameof(listId));
            }

            todoLists.Remove(list);
        }

        public void Rename(string newName)
        {
            Profile.ChangeName(newName);
        }
    }
}
