﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.DomainModel.Entities
{
    public class UserProfile : IUnique<int>
    {
        public int Id { get; private set; }

        public User User { get; private set; }

        public string Name { get; private set; }

        public DateTime RegisterDate { get; private set; }

        public UserProfile(int id, User user, string name, DateTime registerDate)
        {
            Id = id;
            User = user;
            Name = name;
            RegisterDate = registerDate;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
