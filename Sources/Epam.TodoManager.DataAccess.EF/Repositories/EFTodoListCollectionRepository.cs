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

        public TodoListCollection GetUserLists(int userId)
        {
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

        public override void Update(TodoListCollection entity)
        {
            DB.TodoListCollection updatedListCollection = mapper.Map<DB.TodoListCollection>(entity);
            DB.TodoListCollection dbListCollection = context.Set<DB.TodoListCollection>().Include(listCollection => listCollection.Lists).Include("Lists.Todos").FirstOrDefault();

            IntKeyEntityEqualityComparer<DB.TodoList> comparer = new IntKeyEntityEqualityComparer<Model.TodoList>();
            IEnumerable<DB.TodoList> deletedLists = dbListCollection.Lists.Except(updatedListCollection.Lists, comparer).ToList();
            IEnumerable<DB.TodoList> addedLists = updatedListCollection.Lists.Except(dbListCollection.Lists, comparer).ToList();
            IEnumerable<DB.TodoList> modifiedLists = dbListCollection.Lists.Except(deletedLists, comparer).ToList();

            if (deletedLists.Count() > 0)
            {
                context.Set<DB.TodoList>().RemoveRange(deletedLists);
            }

            foreach (var list in addedLists)
            {
                list.ListCollection = null;
            }

            if (addedLists.Count() > 0)
            {
                context.Set<DB.TodoList>().AddRange(addedLists);
            }

            foreach (var list in modifiedLists)
            {
                var updatedList = updatedListCollection.Lists.Single(l => l.Id == list.Id);
                context.Entry(list).State = EntityState.Modified;

                list.Title = updatedList.Title;

                UpdateDbList(list, updatedList);
            }

            //context.SaveChanges();
        }

        private void UpdateDbList(DB.TodoList dbList, DB.TodoList updatedList)
        {
            dbList.Title = updatedList.Title;

            IntKeyEntityEqualityComparer<DB.Todo> todoComparer = new IntKeyEntityEqualityComparer<DB.Todo>();
            IEnumerable<DB.Todo> deletedTodos = dbList.Todos.Except(updatedList.Todos, todoComparer).ToList();
            IEnumerable<DB.Todo> addedTodos = updatedList.Todos.Except(dbList.Todos, todoComparer).ToList();
            IEnumerable<DB.Todo> modifiedTodos = dbList.Todos.Except(deletedTodos, todoComparer).ToList();

            if (deletedTodos.Count() > 0)
            {
                context.Set<DB.Todo>().RemoveRange(deletedTodos);
            }

            foreach (var item in addedTodos)
            {
                item.List = null;
            }

            if (addedTodos.Count() > 0)
            {
                context.Set<DB.Todo>().AddRange(addedTodos);
            }

            foreach (var item in modifiedTodos)
            {
                var updatedItem = updatedList.Todos.Single(todo => todo.Id == item.Id);

                item.Index = updatedItem.Index;
                item.DueDate = updatedItem.DueDate;
                item.IsCompleted = updatedItem.IsCompleted;
                item.Note = updatedItem.Note;
                item.Text = updatedItem.Text;

                context.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
