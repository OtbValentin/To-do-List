using System.Collections.Generic;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class User : IUnique<int>
    {
        public int Id { get; private set; }
        
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public IEnumerable<TodoList> TodoLists { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public User(int id)
        {
            Id = id;
            TodoLists = new List<TodoList>();
            Roles = new List<Role>();
        }
    }
}
