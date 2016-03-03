using System;
using System.Collections.Generic;
using Epam.TodoManager.DomainModel.Entities;
using System.Linq.Expressions;

namespace Epam.TodoManager.BusinessLogic.UserService
{
    public interface IUserService
    {
        void Create(string email, string name, string passwordHash);
        User Find(int userId);
        User Find(string email);
        void ChangeName(int userId, string newName);
    }
}
