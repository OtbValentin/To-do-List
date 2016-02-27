using System.Collections.Generic;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class Role : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
