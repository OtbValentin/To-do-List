using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class TodoList : IUnique<int>
    {
        private List<Todo> todoItems;

        public int Id { get; private set; }

        public int UserId { get; set;  }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public IEnumerable<Todo> TodoItems
        {
            get { return todoItems; }
        }

        public TodoList(int id, IEnumerable<Todo> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Id = id;
            todoItems = items.ToList();
        }
    }
}
