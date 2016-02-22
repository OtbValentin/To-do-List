using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAPI.Entities
{
    public class TodoList : IUnique<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Todo> Todos;
    }
}
