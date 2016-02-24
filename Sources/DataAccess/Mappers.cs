using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;
using EF = DataAccess.EntityFramework;

namespace DataAccess
{
    internal class Mapper : IMapper<EF.User, User>
    {
        public User Map(EF.User entity)
        {
            throw new NotImplementedException();
        }

        public EF.User ReverseMap(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
