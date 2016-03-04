using Epam.TodoManager.DomainModel.Entities;
using DB = Epam.TodoManager.DataAccess.EF.Model;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using System.Data.Entity;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFTodoListCollectionRepository : EFIntKeyGenericRepository<TodoListCollection, DB.TodoListCollection>,
        ITodoListCollectionRepository
    {
        public EFTodoListCollectionRepository(DbContext context)
            : base(context)
        {

        }
    }
}
