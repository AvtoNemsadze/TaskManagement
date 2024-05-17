using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Persistence.Configuration.Task
{
    public class TaskPriorityEntityConfiguration : IEntityTypeConfiguration<TaskPriorityEntity>
    {
        public void Configure(EntityTypeBuilder<TaskPriorityEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd();

            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
              .IsRequired()
              .HasDefaultValue(false);
        }
    }
}
