using Epam.TodoManager.DomainModel.Entities;
using DB = Epam.TodoManager.DataAccess.EF.Model;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using System.Data.Entity;
using System;
using System.Linq;
using AutoMapper;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFTodoListCollectionRepository : EFIntKeyGenericRepository<TodoListCollection, DB.TodoListCollection>,
        ITodoListCollectionRepository
    {
        public EFTodoListCollectionRepository(DbContext context)
            : base(context)
        {

        }

        // Single or FirstOrDefault with custom exception
        public TodoListCollection GetUserLists(int userId)
        {
            DB.TodoListCollection dbListColection = context.Set<DB.TodoListCollection>().Single(list => list.UserId == userId);

            return Mapper.Map<TodoListCollection>(dbListColection);
        }

        public override void Update(TodoListCollection entity)
        {
            DB.TodoListCollection dbListCollection = context.Set<DB.TodoListCollection>().Find(entity.Id);

            context.Entry(dbListCollection).State = EntityState.Modified;

            foreach (DB.TodoList list in dbListCollection.Lists)
            {
                context.Entry(list).State = EntityState.Modified;
            }
        }
    }
}
