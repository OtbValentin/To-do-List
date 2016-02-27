using System;
using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime RegisterDate { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<TodoList> Lists { get; set; }
    }
}
