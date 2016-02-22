using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessAPI.Entities
{
    public class Todo : IUnique<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }
    }
}
