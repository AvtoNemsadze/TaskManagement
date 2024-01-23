using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Team.Commands.DeleteTeam
{
    public class DeleteTeamCommand : IRequest
    {
        public int TeamId { get; set; }
    }
}
