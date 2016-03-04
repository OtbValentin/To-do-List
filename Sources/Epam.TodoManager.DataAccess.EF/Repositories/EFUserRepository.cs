using Epam.TodoManager.DataAccess.Interface.Repositories;
using Epam.TodoManager.DomainModel.Entities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using AutoMapper;
using DB = Epam.TodoManager.DataAccess.EF.Model;

namespace Epam.TodoManager.DataAccess.EF.Repositories
{
    public class EFUserRepository : EFIntKeyGenericRepository<User, DB.User>, IUserRepository
    {
        public EFUserRepository(DbContext context)
            : base(context)
        {

        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}