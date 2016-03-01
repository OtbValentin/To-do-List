using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.DataAccess.Interface.Repositories;

namespace Epam.TodoManager.BusinessLogic.TodoListService
{
    public class TodoListService : ITodoListService
    {
        private IRepository<TodoList, int> todoListRepository;

        public TodoListService(IRepository<TodoList, int> todoListRepository)
        {
            this.todoListRepository = todoListRepository;
        }

        public void AddTodo(int listId, string todoText)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist");
            }

            List<Todo> items = new List<Todo>(list.TodoItems);
            items.Add(new Todo(0, list, todoText, false));

            list = new TodoList(list.Id, list.User, list.Title, list.DueDate, items);

            todoListRepository.Update(list);
        }

        public void Delete(int listId)
        {
            todoListRepository.Delete(listId);
        }

        public TodoList Find(int listId)
        {
            return todoListRepository.Find(listId);
        }

        public void MoveTodoToAnotherList(int listId, int newListId, int todoId)
        {
            TodoList oldList = todoListRepository.Find(listId);

            if (oldList == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(listId));
            }

            TodoList newList = todoListRepository.Find(newListId);

            if (newList == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(newListId));
            }

            Todo todoItem = oldList.TodoItems.FirstOrDefault(item => item.Id == todoId);

            if (todoItem == null)
            {
                throw new ArgumentException("A specified list doesn't contain todo item with a specified id", nameof(listId));
            }

            oldList = new TodoList(oldList.Id, oldList.User, oldList.Title, oldList.DueDate,
                oldList.TodoItems.Where(item => item.Id != todoId));

            todoListRepository.Update(oldList);

            List<Todo> items = new List<Todo>(newList.TodoItems);
            items.Add(todoItem);

            newList = new TodoList(newList.Id, newList.User, newList.Title, newList.DueDate, items);
            todoListRepository.Update(newList);
        }

        public void Rename(int listId, string newTitle)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(list));
            }

            list = new TodoList(list.Id, list.User, newTitle, list.DueDate, list.TodoItems);
        }

        public void Reorder(int listId, int todoId, int index)
        {
            TodoList list = todoListRepository.Find(listId);

            if (list == null)
            {
                throw new ArgumentException("The list with this id doesn't exist", nameof(list));
            }

            Todo todoItem = list.TodoItems.FirstOrDefault(item => item.Id == todoId);

            if (todoItem == null)
            {
                throw new ArgumentException("A specified list doesn't contain todo item with a specified id", nameof(listId));
            }

            List<Todo> reorderedItems = new List<Todo>(list.TodoItems);

            int currentIndex = reorderedItems.IndexOf(todoItem);
            reorderedItems.RemoveAt(currentIndex);
            reorderedItems.Insert(index, todoItem);

            list = new TodoList(list.Id, list.User, list.Title, list.DueDate, reorderedItems);

            todoListRepository.Update(list);
        }
    }
}
