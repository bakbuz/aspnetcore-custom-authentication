using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>(opts => {
            //    opts.HasKey(e => e.Id);

            //}).has;

            //modelBuilder.Entity<User>()
            //    .HasMany<UserRole>();

        }
    }
}