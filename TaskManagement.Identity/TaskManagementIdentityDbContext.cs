using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Constants;
using TaskManagement.Domain.Entities;
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

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is ApplicationUser
            && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((ApplicationUser)entity.Entity).CreatedAt = DateTime.Now;
                    ((ApplicationUser)entity.Entity).UpdatedAt = DateTime.Now;
                }
                else
                {
                    ((ApplicationUser)entity.Entity).UpdatedAt = DateTime.Now;
                }
            }
        }
    }
}