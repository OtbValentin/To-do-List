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
            DB.User user = context.Set<DB.User>().Include(u => u.Profile).FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            return mapper.Map<User>(user);
        }

        public override User Find(int key)
        {
            DB.User user = context.Set<DB.User>().Include(u => u.Profile).FirstOrDefault(u => u.Id == key);

            if (user == null)
            {
                return null;
            }

            return mapper.Map<User>(user);
        }

        public override void Create(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DB.User efEntity = mapper.Map<DB.User>(entity);
            efEntity.ListCollection = new DB.TodoListCollection();
            context.Set<DB.User>().Add(efEntity);
            //context.SaveChanges();
        }

        public override void Update(User entity)
        {
            DB.User user = mapper.Map<DB.User>(entity);

            DB.User dbUser = context.Set<DB.User>().Include(u => u.Profile).FirstOrDefault(u => u.Id == entity.Id);
            context.Entry(dbUser).State = EntityState.Modified;
            context.Entry(dbUser.Profile).State = EntityState.Modified;

            dbUser.Email = user.Email;
            dbUser.PasswordHash = user.PasswordHash;
            dbUser.Profile.Name = entity.Profile.Name;
        }
    }
}