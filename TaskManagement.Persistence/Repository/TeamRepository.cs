using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Domain.Entities.Team;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repository
{
    public class TeamRepository : GenericRepository<TeamEntity>, ITeamRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TeamRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TeamEntity?> GetTeamWithDetailsAsync(int id, CancellationToken cancellationToken)
        {
            var team = await _dbContext.Teams
                .Include(q => q.TeamMembers)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);

            return team;
        }
    }
}
