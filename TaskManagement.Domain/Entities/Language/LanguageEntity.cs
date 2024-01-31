using System;


namespace TaskManagement.Domain.Entities.Language
{
    public class LanguageEntity : BaseEntity
    {
        public string Prefix { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
