using System;
using System.Collections.Generic;
using Epam.TodoManager.DomainModel.Entities;
using Epam.TodoManager.DataAccess.Interface.Repositories;

namespace Epam.TodoManager.BusinessLogic.RoleService
{
    public class RoleService : IRoleService
    {
        private IRepository<Role, int> roleRepository;

        public RoleService(IRepository<Role, int> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public void Create(string name, string description)
        {
            roleRepository.Create(new Role(0) { Name = name, Description = description });
        }

        public void Delete(int id)
        {
            roleRepository.Delete(id);
        }

        public Role Find(int id)
        {
            return roleRepository.Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return roleRepository.GetAll();
        }

        public void Rename(string newName, int roleId)
        {
            Role role = roleRepository.Find(roleId);

            if (role == null)
            {
                throw new ArgumentException(nameof(roleId), "The role with this id doesn't exist");
            }

            role.Name = newName;
        }
    }
}
