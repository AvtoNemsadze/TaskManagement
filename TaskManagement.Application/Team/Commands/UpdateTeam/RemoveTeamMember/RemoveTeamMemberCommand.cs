using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Team.Commands.UpdateTeam.RemoveTeamMember
{
    public class RemoveTeamMemberCommand : IRequest<BaseCommandResponse>
    {
        public int TeamId { get; set; }
        public int UserIdToRemove { get; set; }
        public int RequestingUserId { get; set; }
    }
}
