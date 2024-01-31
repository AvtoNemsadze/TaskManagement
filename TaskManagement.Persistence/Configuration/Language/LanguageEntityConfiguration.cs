using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.Language;

namespace TaskManagement.Persistence.Configuration.Language
{
    public class LanguageEntityConfiguration : IEntityTypeConfiguration<LanguageEntity>
    {
        public void Configure(EntityTypeBuilder<LanguageEntity> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.Prefix).IsRequired();
            builder.Property(l => l.Name).IsRequired();
        }
    }
}
