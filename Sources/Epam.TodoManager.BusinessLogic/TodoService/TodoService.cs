using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public class TodoService : ITodoService
    {
        private IRepository<TodoList, int> todoListRepository;

        public void Delete(int listId, int todoId)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(listId));
            }

            Todo todoItem = list.TodoItems.FirstOrDefault(item => item.Id == todoId);

            if (todoItem == null)
            {
                throw new ArgumentException("A specified list doesn't contain todo item with a specified id", nameof(listId));
            }

            List<Todo> todoItems = new List<Todo>(list.TodoItems);
            todoItems.Remove(todoItem);

            list = new TodoList(list.Id, list.User, list.Title, list.DueDate, todoItems);
        }

        public void EditNote(int listId, int todoId, string note)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(listId));
            }

            Todo todoItem = list.TodoItems.FirstOrDefault(item => item.Id == todoId);

            if (todoItem == null)
            {
                throw new ArgumentException("A specified list doesn't contain todo item with a specified id", nameof(listId));
            }

            List<Todo> todoItems = new List<Todo>(list.TodoItems);
            int index = todoItems.IndexOf(todoItem);
            todoItems.Remove(todoItem);
            todoItems.Insert(index, new Todo(todoItem.Id, todoItem.List, todoItem.Text, todoItem.IsCompleted, note));

            list = new TodoList(list.Id, list.User, list.Title, list.DueDate, todoItems);

            todoListRepository.Update(list);

        }

        public void Rename(int listId, int todoId, string newName)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(listId));
            }

            Todo todoItem = list.TodoItems.FirstOrDefault(item => item.Id == todoId);

            if (todoItem == null)
            {
                throw new ArgumentException("A specified list doesn't contain todo item with a specified id", nameof(listId));
            }

            List<Todo> todoItems = new List<Todo>(list.TodoItems);
            int index = todoItems.IndexOf(todoItem);
            todoItems.Remove(todoItem);
            todoItems.Insert(index, new Todo(todoItem.Id, todoItem.List, newName, todoItem.IsCompleted, todoItem.Note));

            list = new TodoList(list.Id, list.User, list.Title, list.DueDate, todoItems);

            todoListRepository.Update(list);
        }

        public void SetCompletionState(int listId, int todoId, bool isCompleted)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(listId));
            }

            Todo todoItem = list.TodoItems.FirstOrDefault(item => item.Id == todoId);

            if (todoItem == null)
            {
                throw new ArgumentException("A specified list doesn't contain todo item with a specified id", nameof(listId));
            }

            List<Todo> todoItems = new List<Todo>(list.TodoItems);
            int index = todoItems.IndexOf(todoItem);
            todoItems.Remove(todoItem);
            todoItems.Insert(index, new Todo(todoItem.Id, todoItem.List, todoItem.Text, isCompleted, todoItem.Note));

            list = new TodoList(list.Id, list.User, list.Title, list.DueDate, todoItems);

            todoListRepository.Update(list);
        }
    }
}
