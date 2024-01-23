using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Team.Commands.UpdateTeam.RemoveUserFromTeam
{
    public class RemoveTeamMemberModel
    {
        public int TeamId { get; set; }
        public int UserIdToRemove { get; set; }
        public int RequestingUserId { get; set; }
    }
}
