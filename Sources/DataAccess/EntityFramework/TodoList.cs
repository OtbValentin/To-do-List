using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DataAccess.EntityFramework
{
    public class TodoList : IUnique<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
