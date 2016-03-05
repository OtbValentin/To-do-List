using Epam.TodoManager.DataAccess.Interface;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.BusinessLogic.TodoService
{
    public class TodoService : ITodoService
    {
        private IUnitOfWork unitOfWork;

        private ITodoListCollectionRepository listRepository;

        public TodoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            listRepository = this.unitOfWork.ListRepository;
        }

        public void CompleteTodo(int userId, int listId, int todoId)
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

            todo.Complete();

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void EditTodoNote(int userId, int listId, int todoId, string newNote)
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

            todo.EditNote(newNote);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void MarkTodoAsUncompleted(int userId, int listId, int todoId)
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

            todo.SetUncomplitedState();

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void MoveTodoToAnotherList(int userId, int sourceListId, int todoId, int destinationListId)
        {
            TodoListCollection listCollection = listRepository.GetUserLists(userId);

            if (listCollection == null)
            {
                throw new ArgumentException("A specified user doesn't exist", nameof(userId));
            }

            TodoList sourceList = listCollection.FirstOrDefault(list => list.Id == sourceListId);

            if (sourceList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(sourceListId));
            }

            TodoList destinationList = listCollection.FirstOrDefault(list => list.Id == destinationListId);

            if (destinationList == null)
            {
                throw new ArgumentException("A specified user doesn't have a list with the specified id", nameof(destinationListId));
            }

            Todo todo = sourceList.FirstOrDefault(item => item.Id == todoId);

            if (todo == null)
            {
                throw new ArgumentException("A specified list doesn't contain the specified todo", nameof(todoId));
            }

            sourceList.RemoveTodo(todo.Id);

            List<Todo> oldTodos = new List<Todo>(destinationList);

            destinationList.AddTodo(todo.Text);
            Todo addedTodo = destinationList.Except(oldTodos).First();

            CopyTodoProperties(todo, addedTodo);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void RenameTodo(int userId, int listId, int todoId, string newName)
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

            todo.ChangeText(newName);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        public void SetTodoDueDate(int userId, int listId, int todoId, DateTime? dueDate)
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

            todo.SetDueDate(dueDate);

            listRepository.Update(listCollection);

            unitOfWork.Commit();
        }

        private void CopyTodoProperties(Todo source, Todo destination)
        {
            destination.ChangeText(source.Text);
            destination.SetDueDate(source.DueDate);
            destination.EditNote(source.Note);

            if (source.IsCompleted)
            {
                destination.Complete();
            }
            else
            {
                destination.SetUncomplitedState();
            }
        }
    }
}
