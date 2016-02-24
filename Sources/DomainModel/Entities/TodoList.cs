using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DomainModel.Entities
{
    public class TodoList : IUnique<int>
    {
        public int Id { get; private set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public IEnumerable<Todo> Todos { get; set; }

        public TodoList(int id)
        {
            Id = id;
            Todos = new List<Todo>();
        }
    }
}
