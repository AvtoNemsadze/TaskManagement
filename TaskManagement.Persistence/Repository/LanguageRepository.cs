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
    }
}
