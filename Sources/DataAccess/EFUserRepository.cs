using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAPI.Entities;
using DataAccessAPI.Repositories;
using DataAccessAPI;

namespace DataAccess
{
    public class EFUserRepository : IUserRepository
    {
        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoList> GetTodoLists(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
