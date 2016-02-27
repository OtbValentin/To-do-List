using Epam.TodoManager.DomainModel.Entities;
using System.Data.Entity;
using Epam.TodoManager.DataAccess.Interface.Repositories;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFTodoListRepository : EFIntKeyGenericRepository<TodoList, Model.TodoList>, IRepository<TodoList, int>
    {
        public EFTodoListRepository(DbContext context, IMapper<TodoList, Model.TodoList> mapper)
            :base(context, mapper)
        {

        }
    }
}
