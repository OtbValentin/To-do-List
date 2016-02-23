using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    internal class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime RegisterDate { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<TodoList> Lists { get; set; }
    }
}
