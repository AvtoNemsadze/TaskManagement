using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Contracts.Services;

namespace TaskManagement.Application.Team.Queries.TeamHelper
{
    public class TeamAuthorizationService : ITeamAuthorizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamAuthorizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsUserTeamAdminAsync(int? userId, int teamId)
        {
            var team = await _unitOfWork.TeamRepository.GetTeamWithDetailsAsync(teamId, CancellationToken.None);

            return team != null && team.CreateUserId == userId;
        }
    }
}
