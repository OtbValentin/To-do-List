using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class User : IUnique<int>
    {
        public int Id { get; private set; }
        
        public UserProfile Profile { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public User(int id, string email, string passwordHash, UserProfile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (passwordHash == null)
            {
                throw new ArgumentNullException(nameof(passwordHash));
            }

            Id = id;
            Email = email;
            PasswordHash = passwordHash;
            Profile = profile;
        }

        public void Rename(string newName)
        {
            Profile.ChangeName(newName);
        }
    }
}
