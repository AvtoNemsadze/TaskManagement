using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Team;
using System.Reflection.Emit;

namespace TaskManagement.Persistence.Configuration.Team
{
    public class TeamMembersEntityConfiguration : IEntityTypeConfiguration<TeamMembersEntity>
    {
        public void Configure(EntityTypeBuilder<TeamMembersEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd();

            builder.HasOne(ut => ut.User)
                .WithMany(u => u.TeamMembers)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            builder.HasOne(ut => ut.Team)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(ut => ut.TeamId)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
              .IsRequired()
              .HasDefaultValue(false);
        }
    }
}
