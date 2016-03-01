using System;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class Role : IUnique<int>
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
