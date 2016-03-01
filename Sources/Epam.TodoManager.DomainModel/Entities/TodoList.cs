using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class TodoList : IUnique<int>
    {
        public int Id { get; private set; }

        public User User { get; private set; }

        public string Title { get; private set; }

        public DateTime? DueDate { get; private set; }

        public IEnumerable<Todo> TodoItems { get; private set; }

        public TodoList(int id, User user, string title, DateTime? dueDate, IEnumerable<Todo> items)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Id = id;
            User = user;
            Title = title;
            DueDate = dueDate;
            TodoItems = items;
        }
    }
}
