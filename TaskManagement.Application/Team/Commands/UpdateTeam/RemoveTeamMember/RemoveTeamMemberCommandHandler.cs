using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Team.Commands.UpdateTeam.RemoveUserFromTeam
{
    public class RemoveTeamMemberCommandHandler : IRequestHandler<RemoveTeamMemberCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUserService _userService;
        public RemoveTeamMemberCommandHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<BaseCommandResponse> Handle(RemoveTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var team = await _unitOfWork.TeamRepository.GetTeamWithDetailsAsync(request.TeamId, cancellationToken);

            if (team == null)
            {
                response.Success = false;
                response.Message = "Team not found";
                return response;
            }

            // Check if the requesting user is the admin of the team
            if (team.CreateUserId != request.RequestingUserId)
            {
                response.Success = false;
                response.Message = "Permission denied. Only the admin can remove team members.";
                return response;
            }

            var userIdsToRemove = await _unitOfWork.TeamMembersRepository.GetUserIdsByTeamIdAsync(request.TeamId, cancellationToken);

            if (userIdsToRemove == null || !userIdsToRemove.Contains(request.UserIdToRemove))
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }

            var user = _userService.GetUser(request.UserIdToRemove);

            var teamMemberToRemove = team.TeamMembers.FirstOrDefault(tm => tm.UserId == request.UserIdToRemove);

            if (teamMemberToRemove != null)
            {
                team.TeamMembers.Remove(teamMemberToRemove);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = $"User ({user.Result.UserName}) removed from the team successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "User is not a member of the team.";
            }

            return response;
        }
    }

}
