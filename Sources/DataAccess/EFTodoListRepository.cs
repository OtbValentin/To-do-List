using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAPI;
using DataAccessAPI.Entities;
using DataAccessAPI.Repositories;

namespace DataAccess
{
    public class EFTodoListRepository : ITodoListRepository
    {
        public void Create(TodoList entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoList> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoList GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoList entity)
        {
            throw new NotImplementedException();
        }
    }
}
