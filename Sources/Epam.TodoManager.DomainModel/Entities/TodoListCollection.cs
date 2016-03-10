using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class TodoListCollection : IUnique<int>, IEnumerable<TodoList>
    {
        private List<TodoList> todoLists;

        public int Id { get; private set; }

        public int Count
        {
            get
            {
                return todoLists.Count;
            }
        }

        public TodoListCollection(int id, IEnumerable<TodoList> lists)
        {
            Id = id;
            todoLists = lists.ToList();
        }

        public void AddTodoList(string title)
        {
            todoLists.Add(new TodoList(0, this, title, new List<Todo>()));
        }

        public void RemoveTodoList(int listId)
        {
            // Fix removing with id
            TodoList list = todoLists.FirstOrDefault(item => item.Id == listId);
            todoLists.Remove(list);
        }

        public IEnumerator<TodoList> GetEnumerator()
        {
            return todoLists.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
