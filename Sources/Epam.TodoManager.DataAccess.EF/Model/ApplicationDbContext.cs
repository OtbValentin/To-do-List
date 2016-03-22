using System.Data.Entity;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOptional<UserProfile>(user => user.Profile).WithRequired(profile => profile.User).WillCascadeOnDelete(true);
            modelBuilder.Entity<User>().HasOptional<TodoListCollection>(user => user.ListCollection).WithRequired(collection => collection.User).WillCascadeOnDelete(true);
            modelBuilder.Entity<TodoList>().HasRequired<TodoListCollection>(list => list.ListCollection).WithMany(collection => collection.Lists).WillCascadeOnDelete(true);
            modelBuilder.Entity<Todo>().HasRequired<TodoList>(todo => todo.List).WithMany(list => list.Todos).WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
