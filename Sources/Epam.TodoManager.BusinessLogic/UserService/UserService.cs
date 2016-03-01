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

        public void Create(string email, string passwordHash)
        {
            userRepository.Create(new User(0, email, passwordHash,
                new UserProfile(0, null, DateTime.Now), new List<TodoList>()));
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

            userRepository.Update(new User(user.Id, user.Email, user.PasswordHash,
                new UserProfile(user.Profile.Id, newName, user.Profile.RegisterDate), user.TodoLists));
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            return userRepository.GetUserRoles(userId);
        }

        public void AddTodoList(int userId, string listTitle)
        {
            User user = userRepository.Find(userId);

            if (user == null)
            {
                throw new ArgumentException("The user with this id doesn't exist");
            }

            todoListRepository.Create(new TodoList(0, user, listTitle, null, new List<Todo>()));
        }
    }
}
