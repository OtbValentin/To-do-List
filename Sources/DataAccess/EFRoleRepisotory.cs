using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAPI.Repositories;
using DomainModel.Entities;
using DomainModel;
using EF = DataAccess.EntityFramework;
using System.Data.Entity;

namespace DataAccess
{
    public class EFRoleRepisotory : EFIntKeyGenericRepository<Role, EF.Role>, IRepository<Role, int>
    {
        public EFRoleRepisotory(DbContext context, IMapper<Role, EF.Role> mapper)
            :base(context, mapper)
        {

        }
    }
}
