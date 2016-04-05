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
        void ChangeEmail(int userId, string newEmail);
        void ChangePassword(int userId, string passwordHash);
        void Delete(int userId);
        void SetAvatar(int userId, byte[] imageBytes);
        byte[] GetAvatar(int userId);
    }
}
