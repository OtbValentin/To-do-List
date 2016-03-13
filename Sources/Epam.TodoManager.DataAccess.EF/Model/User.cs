using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public UserProfile Profile { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int ListCollectionId { get; set; }

        public TodoListCollection ListCollection { get; set; }
    }
}
