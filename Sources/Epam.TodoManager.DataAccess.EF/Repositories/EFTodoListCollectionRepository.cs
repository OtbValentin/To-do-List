using Epam.TodoManager.DomainModel.Entities;
using DB = Epam.TodoManager.DataAccess.EF.Model;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using System.Data.Entity;
using System;
using System.Linq;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFTodoListCollectionRepository : EFIntKeyGenericRepository<TodoListCollection, DB.TodoListCollection>,
        ITodoListCollectionRepository
    {
        public EFTodoListCollectionRepository(DbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        // Single or FirstOrDefault with custom exception
        // Include todos when loading lists
        public TodoListCollection GetUserLists(int userId)
        {
            //DB.TodoListCollection dbListColection = context.Set<DB.TodoListCollection>().Include(collection => collection.Lists).Single(list => list.Id == userId);

            //return mapper.Map<TodoListCollection>(dbListColection);

            return Find(userId);
        }

        public override TodoListCollection Find(int key)
        {
            var listCollection = context.Set<DB.TodoListCollection>().Include(collection => collection.Lists).Include("Lists.Todos").FirstOrDefault(collection => collection.Id == key);

            if (listCollection == null)
            {
                return null;
            }

            return mapper.Map<TodoListCollection>(listCollection);
        }

        // Handle nonexisting users
        public override void Update(TodoListCollection entity)
        {
            DB.TodoListCollection updatedListCollection = mapper.Map<DB.TodoListCollection>(entity);
            DB.TodoListCollection dbListCollection = context.Set<DB.TodoListCollection>().Include(listCollection => listCollection.Lists).FirstOrDefault();

            IntKeyEntityEqualityComparer<DB.TodoList> comparer = new IntKeyEntityEqualityComparer<Model.TodoList>();
            IEnumerable<DB.TodoList> deletedLists = dbListCollection.Lists.Except(updatedListCollection.Lists, comparer).ToList();
            IEnumerable<DB.TodoList> addedLists = updatedListCollection.Lists.Except(dbListCollection.Lists, comparer).ToList();
            IEnumerable<DB.TodoList> modifiedLists = dbListCollection.Lists.Except(deletedLists, comparer).ToList();

            foreach (var list in deletedLists)
            {
                dbListCollection.Lists.Remove(list);
            }

            foreach (var list in addedLists)
            {
                list.ListCollection = null;
                dbListCollection.Lists.Add(list);
            }

            foreach (var list in modifiedLists)
            {
                var updatedList = updatedListCollection.Lists.Single(l => l.Id == list.Id);
                context.Entry(list).State = EntityState.Modified;

                list.Title = updatedList.Title;

                UpdateDbList(list, updatedList);
            }
        }

        private void UpdateDbList(DB.TodoList dbList, DB.TodoList updatedList)
        {
            dbList.Title = updatedList.Title;

            IntKeyEntityEqualityComparer<DB.Todo> todoComparer = new IntKeyEntityEqualityComparer<DB.Todo>();
            IEnumerable<DB.Todo> deletedTodos = dbList.Todos.Except(updatedList.Todos, todoComparer);
            IEnumerable<DB.Todo> addedTodos = updatedList.Todos.Except(dbList.Todos, todoComparer).ToList();
            IEnumerable<DB.Todo> modifiedTodos = dbList.Todos.Except(deletedTodos, todoComparer).ToList();

            foreach (var item in deletedTodos)
            {
                dbList.Todos.Remove(item);
            }

            foreach (var item in addedTodos)
            {
                item.List = null;
                dbList.Todos.Add(item);
            }

            foreach (var item in modifiedTodos)
            {
                var updatedItem = updatedList.Todos.Single(todo => todo.Id == item.Id);

                item.DueDate = updatedItem.DueDate;
                item.IsCompleted = updatedItem.IsCompleted;
                item.Note = updatedItem.Note;
                item.Text = updatedItem.Text;
                //item.List = null;
                //item.ListId = updatedItem.ListId;

                context.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
