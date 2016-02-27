namespace Epam.TodoManager.DomainModel.Entities
{
    public class Role : IUnique<int>
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Role(int id)
        {
            Id = id;
        }
    }
}
