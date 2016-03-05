﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class TodoListCollection : IEntity<int>
    {
        public int Id { get; private set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<TodoList> Lists { get; set; }
    }
}
