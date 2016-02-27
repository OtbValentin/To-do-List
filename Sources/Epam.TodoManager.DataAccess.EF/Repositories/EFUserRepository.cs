using Epam.TodoManager.DomainModel.Entities;
using System.Data.Entity;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFUserRepository : EFIntKeyGenericRepository<User, Model.User>
    {
        public EFUserRepository(DbContext context, IMapper<User, Model.User> mapper)
            : base(context, mapper)
        {

        }
    }
}