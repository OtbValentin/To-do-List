using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.TodoManager.Presentation.WebApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int List { get; set; }
        public string Text { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class NewTodoItem
    {
        [Required]
        public int List { get; set; }
        [Required]
        public string Text { get; set; }
    }

    public class UpdatedTodoItem
    {
        [Required]
        public int List { get; set; }
        public string Text { get; set; }
        public string Note { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}