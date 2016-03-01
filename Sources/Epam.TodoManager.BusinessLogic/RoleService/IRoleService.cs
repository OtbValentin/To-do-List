using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.TodoManager.DomainModel.Entities;

namespace Epam.TodoManager.BusinessLogic.RoleService
{
    public interface IRoleService
    {
        void Create(string name, string description);
        Role Find(int id);
        void Rename(string newName, int roleId);
        void Delete(int id);
    }
}
