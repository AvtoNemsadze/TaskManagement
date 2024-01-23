using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Enums;

namespace TaskManagement.Application.Team.Commands.UpdateTeam.BlockTeamMember
{
    public class BlockTeamMemberModel
    {
        public int TeamId { get; set; }
        public int UserIdToBlock { get; set; }
        public int RequestingUserId { get; set; }
        public BlockDuration Duration { get; set; }
    }
}
