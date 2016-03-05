using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class User : IUnique<int>
    {
        public int Id { get; private set; }

        public UserProfile Profile { get; private set; }

        public int ListCollectionId { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public User(int id, int listCollectionId, string email, string passwordHash, UserProfile profile)
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
            ListCollectionId = listCollectionId;
            Email = email;
            PasswordHash = passwordHash;
            Profile = profile;
        }

        public void Rename(string name)
        {
            Profile.ChangeName(name);
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }
    }
}
