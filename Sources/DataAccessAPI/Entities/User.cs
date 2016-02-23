using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAPI;

namespace DataAccessAPI.Entities
{
    public class User : IUnique<int>
    {
        public int Id { get; set; }
        
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public IEnumerable<TodoList> TodoLists { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public User()
        {
            TodoLists = new List<TodoList>();
            Roles = new List<Role>();
        }
    }
}
