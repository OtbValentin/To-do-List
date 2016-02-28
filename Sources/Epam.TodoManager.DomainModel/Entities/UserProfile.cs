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

        public string Name { get; set; }

        public DateTime RegisterDate { get; set; }

        public UserProfile(int id)
        {
            Id = id;
        }
    }
}
