using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Team;
using TaskManagement.Domain.Entities.Comment;

namespace TaskManagement.Persistence.Configuration.Comment
{

    public class CommentEntityConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                 .Property(e => e.Id)
                 .ValueGeneratedOnAdd();

            builder
                .HasOne(e => e.TaskEntity)
                .WithMany(t => t.Comments)
                .HasForeignKey(e => e.TaskId)
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
