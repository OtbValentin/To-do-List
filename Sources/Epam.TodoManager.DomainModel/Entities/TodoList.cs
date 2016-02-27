using System;
using System.Collections.Generic;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class TodoList : IUnique<int>
    {
        public int Id { get; private set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public TodoList(int id)
        {
            Id = id;
        }
    }
}
