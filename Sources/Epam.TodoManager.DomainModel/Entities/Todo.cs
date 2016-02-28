namespace Epam.TodoManager.DomainModel.Entities
{
    public class Todo : IUnique<int>
    {
        public int Id { get; private set; }

        public int ListId { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public Todo(int id)
        {
            Id = id;
        }
    }
}
