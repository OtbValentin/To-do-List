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

        private List<Todo> todoItems;

        public IEnumerable<Todo> TodoItems
        {
            get { return todoItems; }
        }

        public TodoList(int id, User user, string title, DateTime? dueDate, IEnumerable<Todo> todoItems)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (todoItems == null)
            {
                throw new ArgumentNullException(nameof(todoItems));
            }

            Id = id;
            User = user;
            Title = title;
            DueDate = dueDate;
            this.todoItems = todoItems.ToList();
        }

        public void SetDueDate(DateTime? dueDate)
        {
            DueDate = dueDate;
        }

        public void ChangeTitle(string title)
        {
            Title = title;
        }

        public void AddTodo(string todoText)
        {
            todoItems.Add(new Todo(0, this, todoText, false, string.Empty));
        }

        public void RemoveTodo(int todoId)
        {
            Todo todo = todoItems.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("A list doesn't contain a todo item with the specified id", nameof(todoId));
            }

            todoItems.Remove(todo);
        }

        public void CompleteTodo(int todoId)
        {
            Todo todo = todoItems.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("A list doesn't contain a todo item with the specified id", nameof(todoId));
            }

            todo.Complete();
        }

        public void SetAsUncomplited(int todoId)
        {
            Todo todo = todoItems.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("A list doesn't contain a todo item with the specified id", nameof(todoId));
            }

            todo.SetUncomplitedState();
        }

        public void ChangeTodoText(int todoId, string text)
        {
            Todo todo = todoItems.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("A list doesn't contain a todo item with the specified id", nameof(todoId));
            }

            todo.ChangeText(text);
        }

        public void EditTodoNote(int todoId, string note)
        {
            Todo todo = todoItems.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("A list doesn't contain a todo item with the specified id", nameof(todoId));
            }

            todo.EditNote(note);
        }
    }
}
