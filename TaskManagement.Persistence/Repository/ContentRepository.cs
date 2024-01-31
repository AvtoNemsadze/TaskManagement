using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities.Language;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repository
{

    public class ContentRepository : GenericRepository<ContentEntity>, IContentRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public ContentRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
