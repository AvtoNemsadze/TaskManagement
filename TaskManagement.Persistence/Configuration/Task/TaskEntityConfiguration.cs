using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Persistence.Configuration.Task
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd();

            builder.Property(e => e.Title)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
              .IsRequired()
              .HasDefaultValue(false);

         
            builder.HasOne(e => e.TaskLevelEntity)
               .WithMany(e => e.Tasks)
               .HasForeignKey(e => e.TaskLevelId)
               .HasConstraintName("FK_Tasks_TaskLevels_TaskLevelId");

            builder.Property(e => e.TaskLevelId)
                .HasConversion<int>();

            builder.HasOne(e => e.TaskStatusEntity)
               .WithMany(e => e.Tasks)
               .HasForeignKey(e => e.TaskStatusId)
               .HasConstraintName("FK_Tasks_TaskStatuses_TaskStatusId");


            builder.HasOne(e => e.TaskPriorityEntity)
              .WithMany(e => e.Tasks)
              .HasForeignKey(e => e.TaskPriorityId)
              .HasConstraintName("FK_Tasks_TaskPriorities_TaskPriorityId");

            builder.Property(e => e.TaskPriorityId)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(e => e.TaskStatusId)
              .IsRequired()
              .HasConversion<int>();
        }
    }
}
