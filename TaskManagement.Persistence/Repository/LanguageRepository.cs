using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities.Language;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repository
{
    public class LanguageRepository : GenericRepository<LanguageEntity>, ILanguageRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public LanguageRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetLanguageIdByPrefixAsync(string languagePrefix)
        {
            var language = await _dbContext.Languages
                .FirstOrDefaultAsync(lang => lang.Prefix == languagePrefix);

            return language?.Id ?? 0; 
        }


        public async Task<string?> GetTranslatedValueAsync(int translatedId, int languageId)
        {
            var translation = await _dbContext.Translations
                .FirstOrDefaultAsync(t => t.ContentId == translatedId && t.LanguageId == languageId);

            return translation?.Value;
        }
    }
}
