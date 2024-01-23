using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Team;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ITeamMembersRepository : IGenericRepository<TeamMembersEntity>
    {
        Task<List<int>> GetUserIdsByTeamIdAsync(int teamId, CancellationToken cancellationToken);
        Task<IEnumerable<TeamMembersEntity>> GetBlockedUserWithExpireBlockDateAsync(DateTime currentTime);
    }
}
