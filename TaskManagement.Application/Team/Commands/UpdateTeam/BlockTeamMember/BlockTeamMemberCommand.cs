using MediatR;
using TaskManagement.Application.Responses;
using TaskManagement.Common.Enums;

namespace TaskManagement.Application.Team.Commands.UpdateTeam.BlockTeamMember
{
    public class BlockTeamMemberCommand : IRequest<BaseCommandResponse>
    {
        public int TeamId { get; set; }
        public int UserIdToBlock { get; set; }
        public int RequestingUserId { get; set; }
        public BlockDuration Duration { get; set; }
    }
}
