using System;
using System.Collections.Generic;
using System.Linq;
using Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.DataAccess.Interface;
using Epam.TodoManager.DataAccess.Interface.Repositories;

namespace Epam.TodoManager.BusinessLogic.TodoListService
{
    public class TodoListService : ITodoListService
    {
        private IUnitOfWork unitOfWork;
        private ITodoListCollectionRepository listRepository;
        private IUserRepository userRepository;

        public TodoListService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            listRepository = this.unitOfWork.ListRepository;
            userRepository = this.unitOfWork.UserRepository;
        }
        public void AddTodo(int userId, int listId, string task)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            TodoList todoList = listCollection.FirstOrDefault(list => list.Id == listId);

            if (todoList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(listId));
            }

            todoList.AddTodo(task);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void AddTodoList(int userId, string title)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            listCollection.AddTodoList(title);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public IEnumerable<TodoList> GetTodoLists(int userId)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            return listCollection;
        }

        public TodoList GetTodoList(int userId, int listId)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            TodoList todoList = listCollection.FirstOrDefault(list => list.Id == listId);

            if (todoList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(listId));
            }

            return todoList;
        }

        public void RemoveTodo(int userId, int listId, int todoId)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            TodoList todoList = listCollection.FirstOrDefault(list => list.Id == listId);

            if (todoList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(listId));
            }

            Todo todo = todoList.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("A specified list doesn't contain the specified todo", nameof(listId));
            }

            todoList.RemoveTodo(todo.Id);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void RemoveTodoList(int userId, int listId)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            TodoList todoList = listCollection.FirstOrDefault(list => list.Id == listId);

            if (todoList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(listId));
            }

            listCollection.RemoveTodoList(todoList.Id);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void RenameList(int userId, int listId, string newName)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            TodoList todoList = listCollection.FirstOrDefault(list => list.Id == listId);

            if (todoList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(listId));
            }

            todoList.ChangeTitle(newName);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void ShiftTodo(int userId, int listId, int todoId, int index)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            TodoList todoList = listCollection.FirstOrDefault(list => list.Id == listId);

            if (todoList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(listId));
            }

            if (index < 0 || index >= todoList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            Todo todo = todoList.FirstOrDefault(item => item.Id == todoId);
            
            if (todo == null)
            {
                throw new ArgumentException("A specified list doesn't contain the specified todo", nameof(listId));
            }

            todoList.ShiftTodo(todo.Id, index);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }
    }
}
