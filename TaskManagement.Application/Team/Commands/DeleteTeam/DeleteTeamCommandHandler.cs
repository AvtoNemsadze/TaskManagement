using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Task.Commands.DeleteTask;
using TaskManagement.Application.Team.Queries.TeamHelper;
using TaskManagement.Common.Exceptions;

namespace TaskManagement.Application.Team.Commands.DeleteTeam
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTeamCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _unitOfWork.TeamRepository.GetTeamWithDetailsAsync(request.TeamId, cancellationToken)
                ?? throw new NotFoundException("Team", request.TeamId);

            team.IsDeleted = true;

            foreach (var members in team.TeamMembers)
            {
                members.IsDeleted = true;
            }

            _unitOfWork.TeamRepository.Update(team);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
