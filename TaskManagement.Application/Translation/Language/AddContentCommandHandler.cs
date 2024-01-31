using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Responses;
using TaskManagement.Common.Exceptions;
using TaskManagement.Domain.Entities.Language;

namespace TaskManagement.Application.Translation.Language
{
    public class AddContentCommandHandler : IRequestHandler<AddContentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddContentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BaseCommandResponse> Handle(AddContentCommand request, CancellationToken cancellationToken)
        {
            // Validate the language IDs
            foreach (var translationDto in request.Translations)
            {
                var languageExists = await _unitOfWork.LanguageRepository.Exists(translationDto.LanguageId);
                if (!languageExists)
                {
                    throw new NotFoundException("language", request.Translations.Select(x => x.LanguageId).FirstOrDefault());
                }
            }

            var content = new ContentEntity
            {
                Key = request.Key,
                Translation = request.Translations.Select(t => new TranslationEntity
                {
                    LanguageId = t.LanguageId,
                    Value = t.Value,
                }).ToList()
            };

            await _unitOfWork.ContentRepository.Add(content);
            await _unitOfWork.Save();

            return new BaseCommandResponse
            {
                Id = content.Id,
                Message = "content added successfully"
            };
        }
    }
}
