using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace DataAccessAPI.Repositories
{
    public interface IRoleRepository : IRepository<Role, int>
    {
    }
}
