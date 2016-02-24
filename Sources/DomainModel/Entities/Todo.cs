using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DomainModel.Entities
{
    public class Todo : IUnique<int>
    {
        public int Id { get; private set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public Todo(int id)
        {
            Id = id;
        }
    }
}
