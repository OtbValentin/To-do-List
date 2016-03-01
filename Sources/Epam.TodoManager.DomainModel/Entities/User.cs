using System;
using System.Collections.Generic;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class User : IUnique<int>
    {
        public int Id { get; private set; }
        
        public UserProfile Profile { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public IEnumerable<TodoList> TodoLists { get; private set; }

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
            TodoLists = todoLists;
        }
    }
}
