using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAPI.Repositories;
using DomainModel;
using DomainModel.Entities;
using System.Data.Entity;

namespace DataAccess
{
    public class EFTodoListRepository : EFIntKeyGenericRepository<TodoList, EntityFramework.TodoList>, IRepository<TodoList, int>
    {
        public EFTodoListRepository(DbContext context, IMapper<TodoList, EntityFramework.TodoList> mapper)
            :base(context, mapper)
        {

        }
    }
}
