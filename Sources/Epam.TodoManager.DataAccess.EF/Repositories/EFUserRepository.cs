using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using AutoMapper;
using DB = Epam.TodoManager.DataAccess.EF.Model;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFUserRepository : EFIntKeyGenericRepository<User, Model.User>, IUserRepository
    {
        public EFUserRepository(DbContext context)
            : base(context)
        {

        }

        public override void Update(User entity)
        {
            DB.User user = Mapper.Map<DB.User>(entity);
            DB.User dbUser = context.Set<DB.User>().Find(entity.Id);
            context.Entry<DB.User>(user).State = EntityState.Modified;

            foreach (DB.TodoList list in user.Lists)
            {
                context.Entry<DB.TodoList>(list).State = EntityState.Modified;
            }

            IEnumerable<DB.TodoList> deletedLists = dbUser.Lists.Except(user.Lists, new TodoListEqualityComparer());

            foreach (DB.TodoList list in deletedLists)
            {
                context.Entry<DB.TodoList>(list).State = EntityState.Deleted;

                foreach (DB.Todo todo in list.Todos)
                {
                    context.Entry<DB.Todo>(todo).State = EntityState.Deleted;
                }
            }

            IEnumerable<DB.TodoList> addedLists = user.Lists.Except(dbUser.Lists, new TodoListEqualityComparer());

            foreach (DB.TodoList list in addedLists)
            {
                context.Entry<DB.TodoList>(list).State = EntityState.Added;

                foreach (DB.Todo todo in list.Todos)
                {
                    context.Entry<DB.Todo>(todo).State = EntityState.Added;
                }
            }

            context.Entry<DB.UserProfile>(user.Profile).State = EntityState.Modified;

            base.Update(entity);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            Model.User user = context.Set<Model.User>().Find(userId);

            return user.Roles.Select(role => new Role(role.Id, role.Name));
        }
    }

    public class TodoListEqualityComparer : IEqualityComparer<DB.TodoList>
    {
        public bool Equals(DB.TodoList x, DB.TodoList y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(DB.TodoList obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}