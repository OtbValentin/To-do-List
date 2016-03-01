using Epam.TodoManager.BusinessLogic.RoleService;
using Domain = Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.BusinessLogic.Mock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.Mock
{
    public class RoleService : IRoleService
    {
        private MockContext context;

        public RoleService()
        {
            context = new MockContext();
        }

        public void Create(string name)
        {
            var newRole = new Role()
            {
                Name = name
            };

            context.Roles.Add(newRole);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = context.Roles.Find(id);
            if (role == null)
                throw new ArgumentException(nameof(id));

            context.Roles.Remove(role);
            context.SaveChanges();
        }

        public Domain.Role Find(int id)
        {
            return context.Roles.Find(id).ToDomainRole();
        }

        public void Rename(string newName, int roleId)
        {
            var role = context.Roles.Find(roleId);
            if (role == null)
                throw new ArgumentException(nameof(roleId));

            role.Name = newName;
            context.SaveChanges();
        }
    }
}
