using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class TodoList : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
