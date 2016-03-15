using System;
using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class TodoList : IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ListCollectionId { get; set; }

        public TodoListCollection ListCollection { get; set; }

        public ICollection<Todo> Todos { get; set; }

        public TodoList()
        {
            Todos = new List<Todo>();
        }
    }
}
