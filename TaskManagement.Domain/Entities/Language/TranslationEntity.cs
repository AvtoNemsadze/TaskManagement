using System;

namespace TaskManagement.Domain.Entities.Language
{
    public class TranslationEntity : BaseEntity
    {
        public string Value { get; set; } = string.Empty;
                                      
        public int ContentId { get; set; }
        public int LanguageId { get; set; }

        // Navigation properties
        public ContentEntity Content { get; set; } = default!;
        public LanguageEntity Language { get; set; } = default!;
    }
}
