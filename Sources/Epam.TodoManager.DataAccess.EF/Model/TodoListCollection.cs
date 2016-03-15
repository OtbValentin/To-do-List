using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class TodoListCollection : IEntity<int>
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<TodoList> Lists { get; set; }

        public TodoListCollection()
        {
            Lists = new List<TodoList>();
        }
    }
}
