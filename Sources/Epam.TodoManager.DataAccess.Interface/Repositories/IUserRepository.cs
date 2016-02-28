using System;
using Epam.TodoManager.DomainModel.Entities;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.Interface.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        IEnumerable<User> Find(Expression<Func<User, bool>> predicate);
        IEnumerable<Role> GetUserRoles(int userId);
    }
}
