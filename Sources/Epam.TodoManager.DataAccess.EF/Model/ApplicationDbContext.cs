using System.Data.Entity;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOptional<UserProfile>(user => user.Profile).WithOptionalDependent().WillCascadeOnDelete(true);
            //modelBuilder.Entity<User>().HasOptional(user => user.ListCollection).WithRequired(collection => collection.User);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
