using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.Language;

namespace TaskManagement.Persistence.Configuration.Language
{
    public class ContentEntityConfiguration : IEntityTypeConfiguration<ContentEntity>
    {
        public void Configure(EntityTypeBuilder<ContentEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(1, 1);

            builder.Property(c => c.Key).IsRequired();

            // Configure one-to-many relationship with translations
            builder.HasMany(c => c.Translation)
                   .WithOne(t => t.Content)
                   .HasForeignKey(t => t.ContentId);
        }
    }
}
