namespace Epam.TodoManager.DomainModel.Entities
{
    public class Todo : IUnique<int>
    {
        public int Id { get; private set; }

        public TodoList List { get; private set; }

        public string Text { get; private set; }

        public bool IsCompleted { get; private set; }

        public Todo(int id, TodoList list, string text, bool isCompleted)
        {
            Id = id;
            List = list;
            Text = text;
            IsCompleted = isCompleted;
        }
    }
}
