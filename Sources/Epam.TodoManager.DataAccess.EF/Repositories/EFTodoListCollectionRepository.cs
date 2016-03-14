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
        public TodoListCollection GetUserLists(int userId)
        {
            DB.TodoListCollection dbListColection = context.Set<DB.TodoListCollection>().Single(list => list.Id == userId);

            return Mapper.Map<TodoListCollection>(dbListColection);
        }

        public override void Update(TodoListCollection entity)
        {
            DB.TodoListCollection updatedListCollection = mapper.Map<DB.TodoListCollection>(entity);
            DB.TodoListCollection dbListCollection = context.Set<DB.TodoListCollection>().Find(entity.Id);

            context.Entry(dbListCollection).State = EntityState.Detached;
            context.Entry(updatedListCollection).State = EntityState.Modified;

            IntKeyEntityEqualityComparer<DB.TodoList> comparer = new IntKeyEntityEqualityComparer<Model.TodoList>();
            IEnumerable<DB.TodoList> deletedLists = dbListCollection.Lists.Except(updatedListCollection.Lists, comparer);
            IEnumerable<DB.TodoList> addedLists = updatedListCollection.Lists.Except(dbListCollection.Lists, comparer);
            IEnumerable<DB.TodoList> modifiedLists = updatedListCollection.Lists.Except(deletedLists).Except(addedLists, comparer);

            // Todo items should be cascade deleted
            foreach (var list in deletedLists)
            {
                context.Entry(list).State = EntityState.Deleted;
            }

            foreach (var list in addedLists)
            {
                context.Entry(list).State = EntityState.Added;
            }

            foreach (var list in modifiedLists)
            {
                context.Entry(list).State = EntityState.Modified;

                foreach (var todo in list.Todos)
                {
                    context.Entry(todo).State = EntityState.Modified;
                }
            }
        }   
    }
}
