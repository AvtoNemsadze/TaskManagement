using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Team.Commands.UpdateTeam.BlockTeamMember
{
    public class BlockTeamMemberCommandHandler : IRequestHandler<BlockTeamMemberCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUserService _userService;
        public BlockTeamMemberCommandHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<BaseCommandResponse> Handle(BlockTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var team = await _unitOfWork.TeamRepository.GetTeamWithDetailsAsync(request.TeamId, cancellationToken);

            if (team == null)
            {
                response.Success = false;
                response.Message = "Team not found";
                return response;
            }

            if (team.CreateUserId != request.RequestingUserId)
            {
                response.Success = false;
                response.Message = "Permission denied. Only the admin can block team members.";
                return response;
            }

            var userIdsToRemove = await _unitOfWork.TeamMembersRepository.GetUserIdsByTeamIdAsync(request.TeamId, cancellationToken);

            if (userIdsToRemove == null || !userIdsToRemove.Contains(request.UserIdToBlock))
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }

            var user = await _userService.GetUser(request.UserIdToBlock);

            var teamMemberToBlock = team.TeamMembers.FirstOrDefault(tm => tm.UserId == request.UserIdToBlock);

            if (teamMemberToBlock != null)
            {
                teamMemberToBlock.IsBlocked = true;
                teamMemberToBlock.BlockedUntil = DateTime.Now.AddDays((int)request.Duration); 
                await _unitOfWork.Save();

                response.Success = true;
                response.Id = request.UserIdToBlock;
                response.Message = $"User ({user.UserName}) blocked from the team until {teamMemberToBlock.BlockedUntil}.";
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
