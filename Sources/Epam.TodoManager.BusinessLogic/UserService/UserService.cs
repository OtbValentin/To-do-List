using System;
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

        public void ChangeEmail(int userId, string newEmail)
        {
            User user = userRepository.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("There is no user with this ID", nameof(userId));
            }

            user.ChangeEmail(newEmail);

            userRepository.Update(user);

            unitOfWork.Commit();
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

        public void ChangePassword(int userId, string passwordHash)
        {
            User user = userRepository.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("There is no user with this ID", nameof(userId));
            }

            user.ChangePassword(passwordHash);

            userRepository.Update(user);

            unitOfWork.Commit();
        }

        public void Create(string email, string name, string passwordHash)
        {
            User existingUser = userRepository.Find(email);
            if (existingUser != null)
            {
                throw new ArgumentException("User with this email already exists", nameof(email));
            }

            var newUser = new User(0, 0, email, passwordHash, new UserProfile(0, name, DateTime.Now));

            userRepository.Create(newUser);

            unitOfWork.Commit();
        }

        public void Delete(int userId)
        {
            userRepository.Delete(userId);

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
