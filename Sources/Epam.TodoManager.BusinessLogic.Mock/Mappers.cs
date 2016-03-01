using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.BusinessLogic.Mock.Entities;

namespace Epam.TodoManager.BusinessLogic.Mock
{
    public static class Mappers
    {
        public static Domain.Role ToDomainRole(this Role mockRole)
        {
            return new Domain.Role(mockRole.Id, mockRole.Name);
        }

        public static Domain.User ToDomainUser(this User mockUser)
        {
            return new Domain.User(mockUser.Id, mockUser.Email, mockUser.Password, null, null);
        }
    }
}
