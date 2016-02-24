using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DomainModel.Entities
{
    public class Role : IUnique<int>
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
