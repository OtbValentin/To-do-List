using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFUserRepository : EFIntKeyGenericRepository<User, Model.User>, IUserRepository
    {
        public EFUserRepository(DbContext context, IMapper<User, Model.User> mapper)
            : base(context, mapper)
        {

        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetUserRoles(int userId)
        {
            Model.User user = context.Set<Model.User>().Find(userId);

            return user.Roles.Select(role => new Role(role.Id, role.Name));
        }
    }
}