using DataAccessAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAPI.Repositories
{
    public interface ITodoListRepository : IRepository<TodoList, int>
    {
    }
}
