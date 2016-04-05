using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.TodoManager.Presentation.WebApi.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<int> TodoItems { get; set; }
    }

    public class PopulatedTodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<TodoItem> TodoItems { get; set; }
    }
}