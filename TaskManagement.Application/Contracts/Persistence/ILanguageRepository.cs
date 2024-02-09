using TaskManagement.Domain.Entities.Language;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ILanguageRepository : IGenericRepository<LanguageEntity>
    {
        Task<int> GetLanguageIdByPrefixAsync(string languagePrefix);
        Task<string?> GetTranslatedValueAsync(int translatedId, int languageId);
    }
}
