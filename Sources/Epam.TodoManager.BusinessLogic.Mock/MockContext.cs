using Epam.TodoManager.BusinessLogic.Mock.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.TodoManager.BusinessLogic.Mock
{
    class MockContext : DbContext
    {
        public MockContext() : base("MockDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
