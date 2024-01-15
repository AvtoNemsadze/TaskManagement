using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
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


    }
}
