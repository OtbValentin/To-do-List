﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DataAccess.EntityFramework
{
    public class Todo : IUnique<int>
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; }

        public TodoList ListId { get; set; }

        public TodoList List { get; set; }
    }
}
