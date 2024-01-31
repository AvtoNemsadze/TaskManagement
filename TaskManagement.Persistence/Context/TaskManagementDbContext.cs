using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Constants;
using TaskManagement.Domain.Entities.Comment;
using TaskManagement.Domain.Entities.Language;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Domain.Entities.Team;
using BaseEntity = TaskManagement.Domain.Entities.BaseEntity;

namespace TaskManagement.Persistence.Context
{
    public class TaskManagementDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
        : base(options)
        {
            try
            {
                _httpContextAccessor = this.GetInfrastructure().GetRequiredService<IHttpContextAccessor>();
            }
            catch (Exception)
            {
                _httpContextAccessor = new HttpContextAccessor();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementDbContext).Assembly);

            TaskManagementDbInitializer.Seed(modelBuilder);
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskLevelEntity> TaskLevels { get; set; }
        public DbSet<TaskStatusEntity> TaskStatuses { get; set; }
        public DbSet<TaskPriorityEntity> TaskPriorities { get; set; }

        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TeamMembersEntity> TeamMembers { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<ContentEntity> Contents { get; set; }
        public DbSet<TranslationEntity> Translations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity
            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentApplicationId = _httpContextAccessor?.HttpContext?.User.FindFirst(CustomClaimTypes.Uid)?.Value ?? string.Empty;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added || entity.State == EntityState.Modified)
                {
                    if (int.TryParse(currentApplicationId, out int userId))
                    {
                        if (entity.State == EntityState.Added)
                        {
                            ((BaseEntity)entity.Entity).CreatedAt = DateTime.Now;
                            ((BaseEntity)entity.Entity).CreateUserId = userId;
                        }
                        else
                        {
                            ((BaseEntity)entity.Entity).UpdatedAt = DateTime.Now;
                            ((BaseEntity)entity.Entity).LastModifiedUserId = userId;
                        }
                    }
                    else
                    {
                        if (entity.State == EntityState.Added)
                        {
                            ((BaseEntity)entity.Entity).CreatedAt = DateTime.Now;
                        }
                        else
                        {
                            ((BaseEntity)entity.Entity).UpdatedAt = DateTime.Now;
                        }
                    }
                }
            }
        }
    }

}