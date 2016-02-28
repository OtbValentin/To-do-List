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

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Create(string email, string passwordHash)
        {
            User user = new User(0, new List<TodoList>())
            {
                Email = email,
                PasswordHash = passwordHash
            };

            userRepository.Create(user);
        }

        public void Delete(int userId)
        {
            userRepository.Delete(userId);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return userRepository.Find(predicate);
        }

        public User Find(int userId)
        {
            return userRepository.Find(userId);
        }

        public User Find(string email)
        {
            return userRepository.Find(user => user.Email == email).FirstOrDefault();
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return userRepository.GetUserRoles(userId);
        }

        public void ChangeName(int userId, string newName)
        {
            if (newName == null)
            {
                throw new ArgumentNullException(nameof(newName));
            }

            if (newName == string.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(newName), "Name shouldn't be an empty string");
            }

            User user = userRepository.Find(userId);
            user.Profile.Name = newName;
        }
    }
}
