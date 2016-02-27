using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessAPI.Repositories;
using DomainModel;
using DomainModel.Entities;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class EFUserRepository : EFIntKeyGenericRepository<User, EntityFramework.User>
    {
        public EFUserRepository(DbContext context, IMapper<User, EntityFramework.User> mapper)
            : base(context, mapper)
        {

        }
    }
}