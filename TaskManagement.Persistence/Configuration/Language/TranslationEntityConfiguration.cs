using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.Language;

namespace TaskManagement.Persistence.Configuration.Language
{
    public class TranslationEntityConfiguration : IEntityTypeConfiguration<TranslationEntity>
    {
        public void Configure(EntityTypeBuilder<TranslationEntity> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            builder.Property(l => l.Value).IsRequired();

            builder.HasOne(l => l.Content)
                   .WithMany(c => c.Translation)
                   .HasForeignKey(l => l.ContentId);

            builder.HasOne(l => l.Language)
                   .WithMany()
                   .HasForeignKey(l => l.LanguageId);
        }
    }
}
