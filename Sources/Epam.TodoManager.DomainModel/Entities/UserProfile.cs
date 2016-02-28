using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class UserProfile : IUnique<int>
    {
        public int Id { get; }

        public UserProfile()
        {

        }
    }
}
