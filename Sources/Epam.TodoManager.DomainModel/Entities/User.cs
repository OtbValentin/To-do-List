using System.Collections.Generic;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class User : IUnique<int>
    {
        public int Id { get; private set; }
        
        public string Email { get; set; }

        public string PasswordHash { get; set; }


        public User(int id)
        {
            Id = id;
        }
    }
}
