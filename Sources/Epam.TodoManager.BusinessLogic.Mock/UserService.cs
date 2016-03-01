using Epam.TodoManager.BusinessLogic.Mock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Epam.TodoManager.BusinessLogic.Mock.Mappers;

namespace Epam.TodoManager.BusinessLogic.Mock
{
    public class UserService : BusinessLogic.UserService.IUserService
    {
        private MockContext context;

        public UserService()
        {
            context = new MockContext();
        }

        public void AddTodoList(int userId, string listTitle)
        {
            throw new NotImplementedException();
        }

        public void ChangeName(int userId, string newName)
        {
            throw new NotImplementedException();
        }

        public void Create(string email, string passwordHash)
        {
            var newUser = new User()
            {
                Email = email,
                Password = passwordHash
            };

            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var user = context.Users.Find(userId);
            if (user == null)
                throw new ArgumentException(nameof(userId));

            context.Users.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<DomainModel.Entities.User> Find(Expression<Func<DomainModel.Entities.User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DomainModel.Entities.User Find(string email)
        {
            var user = context.Users.FirstOrDefault(dbUser => dbUser.Email == email);
            if (user == null)
                throw new ArgumentException(nameof(email));

            return user.ToDomainUser();
        }

        public DomainModel.Entities.User Find(int userId)
        {
            var user = context.Users.Find(userId);
            if (user == null)
                throw new ArgumentException(nameof(userId));

            return user.ToDomainUser();
        }

        public IEnumerable<DomainModel.Entities.Role> GetUserRoles(int userId)
        {
            var user = context.Users.Find(userId);
            if (user == null)
                throw new ArgumentException(nameof(userId));

            return user.Roles.Select(role => role.ToDomainRole());
        }
    }
}
