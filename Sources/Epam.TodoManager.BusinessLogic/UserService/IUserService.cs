using System;
using System.Collections.Generic;
using Epam.TodoManager.DomainModel.Entities;
using System.Linq.Expressions;

namespace Epam.TodoManager.BusinessLogic.UserService
{
    public interface IUserService
    {
        void Create(string email, string passwordHash);
        User Find(int userId);
        User Find(string email);
        IEnumerable<User> Find(Expression<Func<User, bool>> predicate);
        void Delete(int userId);
        void ChangeName(int userId, string newName);
        void AddTodoList(int userId, string listTitle);
        IEnumerable<Role> GetUserRoles(int userId);
    }
}
