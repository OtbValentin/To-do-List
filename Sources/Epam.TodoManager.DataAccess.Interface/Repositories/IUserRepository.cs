using System;
using Epam.TodoManager.DomainModel.Entities;
using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.Interface.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {
        User Find(string email);
    }
}
