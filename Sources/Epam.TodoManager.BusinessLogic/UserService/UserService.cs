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
        private IRepository<User, int> userRepository;
        private IRepository<Role, int> roleRepository;

        public UserService(IRepository<User, int> userRepository)
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
            //User repository needs a find method with a predicate
            return null;
        }

        public User Find(int userId)
        {
            return userRepository.Find(userId);
        }

        public User Find(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return null;
        }

        public void ChangeName(int userId, string newName)
        {
            User user = userRepository.Find(userId);
            user.Pro
        }
    }
}
