using MediatR;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Translation.Language
{
    public class AddContentCommand : IRequest<BaseCommandResponse>
    {
        public string Key { get; set; } = string.Empty;
        public List<TranslationDto> Translations { get; set; } = default!;
    }
}
