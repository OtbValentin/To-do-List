using System;
using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.EF.Model
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
