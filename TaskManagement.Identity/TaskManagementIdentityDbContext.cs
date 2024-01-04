using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Identity.Configurations;
using TaskManagement.Identity.Models;

namespace TaskManagement.Identity
{
    public class TaskManagementIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public TaskManagementIdentityDbContext(DbContextOptions<TaskManagementIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is ApplicationUser &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (ApplicationUser)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.UpdatedAt = null;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.UpdatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}