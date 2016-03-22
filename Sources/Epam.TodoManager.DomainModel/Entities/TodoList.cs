using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class TodoList : IUnique<int>, IEnumerable<Todo>
    {
        private List<Todo> todoItems;

        public IEnumerable<Todo> TodoItems
        {
            get
            {
                return todoItems;
            }

            private set { }
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public int Count
        {
            get
            {
                return todoItems.Count;
            }
        }

        public TodoList(int id, string title, IEnumerable<Todo> todoItems)
        {
            if (todoItems == null)
            {
                throw new ArgumentNullException(nameof(todoItems));
            }

            Id = id;
            Title = title;
            this.todoItems = todoItems.ToList();
        }

        public void AddTodo(string task)
        {
            todoItems.Insert(0, new Todo(0, task, false, string.Empty, null));
        }

        public void RemoveTodo(int todoId)
        {
            todoItems.Remove(todoItems.FirstOrDefault(item => item.Id == todoId));
        }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void ShiftTodo(int todoId, int index)
        {
            Todo todo = todoItems.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("The list doesn't contain a todo with the specified id");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            todoItems.Remove(todo);
            todoItems.Insert(index, todo);
        }

        public IEnumerator<Todo> GetEnumerator()
        {
            return TodoItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
