using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Configuration.User
{
    public class DomainUserEntityConfiguration : IEntityTypeConfiguration<DomainUserEntity>
    {
        public void Configure(EntityTypeBuilder<DomainUserEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                 .ValueGeneratedOnAdd();
        }
    }
}
