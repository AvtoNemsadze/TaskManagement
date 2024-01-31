namespace TaskManagement.Application.Translation.Language
{
    public class TranslationDto
    {
        public int LanguageId { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class AddContentRequestDto
    {
        public string Key { get; set; } = string.Empty;
        public List<TranslationDto> Translations { get; set; } = default!;
    }
}
