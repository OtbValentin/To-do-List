﻿using System;
using Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.DataAccess.Interface;
using Epam.TodoManager.DataAccess.Interface.Repositories;

namespace Epam.TodoManager.BusinessLogic.UserService
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;

        private IUserRepository userRepository;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            userRepository = this.unitOfWork.UserRepository;
        }

        public void ChangeName(int userId, string newName)
        {
            User user = userRepository.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("There is no user with this ID", nameof(userId));
            }

            user.Rename(newName);

            userRepository.Update(user);

            unitOfWork.Commit();
        }

        public void Create(string email, string name, string passwordHash)
        {
            User user = userRepository.Find(email);

            if (user == null)
            {
                throw new ArgumentException("User with this email already exists", nameof(email));
            }

            userRepository.Create(user);

            unitOfWork.Commit();
        }

        public User Find(string email)
        {
            return userRepository.Find(email);
        }

        public User Find(int userId)
        {
            return userRepository.Find(userId);
        }
    }
}
