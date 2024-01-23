using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Domain.Entities.Team;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repository
{
    public class TeamMembersRepository : GenericRepository<TeamMembersEntity>, ITeamMembersRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TeamMembersRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<int>> GetUserIdsByTeamIdAsync(int teamId, CancellationToken cancellationToken)
        {
            var userIds = await _dbContext.TeamMembers
                .Where(tm => tm.TeamId == teamId)
                .Select(tm => tm.UserId)
                .ToListAsync(cancellationToken);

            return userIds;
        }

        public async Task<IEnumerable<TeamMembersEntity>> GetBlockedUserWithExpireBlockDateAsync(DateTime currentTime)
        {
            return await _dbContext.TeamMembers
                .Where(x => x.BlockedUntil < currentTime)
                .ToListAsync();
        }
    }
}
