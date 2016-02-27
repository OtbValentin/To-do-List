using Epam.TodoManager.DomainModel.Entities;
using System.Data.Entity;
using Epam.TodoManager.DataAccess.Interface.Repositories;
using DB = Epam.TodoManager.DataAccess.EF.Model;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFRoleRepisotory : EFIntKeyGenericRepository<Role, DB.Role>, IRepository<Role, int>
    {
        public EFRoleRepisotory(DbContext context, IMapper<Role, DB.Role> mapper)
            :base(context, mapper)
        {

        }
    }
}
