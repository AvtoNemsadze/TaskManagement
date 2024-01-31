using System;


namespace TaskManagement.Domain.Entities.Language
{
    public class ContentEntity : BaseEntity
    {
        public string Key { get; set; } = default!;

        public ICollection<TranslationEntity> Translation { get; set; } = default!;
    }
}
