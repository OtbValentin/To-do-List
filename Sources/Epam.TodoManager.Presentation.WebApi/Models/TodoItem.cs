using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.TodoManager.Presentation.WebApi.Models
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public int List { get; private set; }
        public string Text { get; private set; }
        public string Note { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime? DueDate { get; private set; }
    }

    public class NewTodoItem
    {
        [Required]
        public int List { get; private set; }
        [Required]
        public string Text { get; set; }
    }

    public class UpdatedTodoItem
    {
        [Required]
        public int List { get; private set; }
        public string Text { get; private set; }
        public string Note { get; private set; }
        public bool? IsCompleted { get; private set; }
        public DateTime? DueDate { get; private set; }
    }
}