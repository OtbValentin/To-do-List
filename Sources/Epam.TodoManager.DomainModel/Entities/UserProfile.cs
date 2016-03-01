using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class UserProfile : IUnique<int>
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public UserProfile(int id, string name, DateTime registerDate)
        {
            Id = id;
            Name = name;
            RegisterDate = registerDate;
        }
    }
}
