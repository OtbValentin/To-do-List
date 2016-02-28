using System.Data.Entity;

namespace Epam.TodoManager.DataAccess.EF.Model
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<Role>(user => user.Roles).WithMany();
            modelBuilder.Entity<User>().HasOptional<UserProfile>(user => user.Profile).WithOptionalDependent().WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}
