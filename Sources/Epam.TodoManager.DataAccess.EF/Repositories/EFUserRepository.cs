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
        public EFUserRepository(DbContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public User Find(string email)
        {
            DB.User user = context.Set<DB.User>().FirstOrDefault(u => u.Email == email);

            //if (user == null)
            //{
            //    throw new ArgumentException("A user with this email doesn't exist", nameof(email));
            //}
            
            return mapper.Map<User>(user);
        }

        public override void Update(User entity)
        {
            DB.User user = mapper.Map<DB.User>(entity);

            context.Entry(user).State = EntityState.Modified;
            context.Entry(user.Profile).State = EntityState.Modified;
        }
    }
}