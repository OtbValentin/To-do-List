using System;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class Todo : IEntity<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public string Note { get; set; }

        public int ListId { get; set; }

        public TodoList List { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
