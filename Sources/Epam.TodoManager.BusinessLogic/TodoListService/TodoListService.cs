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
            Todo todoItem = new Todo(0) { ListId = listId, Text = todoText };
            TodoList list = todoListRepository.Find(listId);

        }

        public void CreateList(int userId, string title)
        {
            throw new NotImplementedException();
        }

        public void Delete(int listId)
        {
            throw new NotImplementedException();
        }

        public TodoList Find(int id)
        {
            throw new NotImplementedException();
        }

        public void MoveTodoToAnotherList(int todoId, int newListId)
        {
            throw new NotImplementedException();
        }

        public void Rename(int listId, string newName)
        {
            throw new NotImplementedException();
        }

        public void Reorder(int listId, int todoId, int index)
        {
            throw new NotImplementedException();
        }
    }
}
