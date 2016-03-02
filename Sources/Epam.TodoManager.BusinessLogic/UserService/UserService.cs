using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.DataAccess.Interface.Repositories;

namespace Epam.TodoManager.BusinessLogic.UserService
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IRepository<Role, int> roleRepository;
        private IRepository<TodoList, int> todoListRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Create(string email, string name, string passwordHash)
        {
            userRepository.Create(new User(0, email, passwordHash,
                new UserProfile(0, name, DateTime.Now), new List<TodoList>()));
        }

        public User Find(int userId)
        {
            return userRepository.Find(userId);
        }

        public User Find(string email)
        {
            return userRepository.Find(user => user.Email == email).FirstOrDefault();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return userRepository.Find(predicate);
        }

        public void Delete(int userId)
        {
            userRepository.Delete(userId);
        }

        public void ChangeName(int userId, string newName)
        {
            User user = userRepository.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("The user with this id doesn't exist");
            }

            user.Rename(newName);
            userRepository.Update(user);
        }

        public void AddTodoList(int userId, string listTitle)
        {
            User user = userRepository.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("The user with this id doesn't exist");
            }

            user.AddTodoList(listTitle);

            userRepository.Update(user);
        }

        public void RemoveTodoList(int userId, int listId)
        {
            User user = userRepository.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("The user with this id doesn't exist");
            }

            user.RemoveTodoList(listId);

            userRepository.Update(user);
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return userRepository.GetUserRoles(userId);
        }














    }
}
