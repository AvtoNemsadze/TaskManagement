using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Responses;
using TaskManagement.Application.Task.Commands.CreateTask;

namespace TaskManagement.Application.Team.Commands.CreateTeam
{
    public class CreateTeamCommand : IRequest<BaseCommandResponse>
    {
        public CreateTeamModel CreateTeamModel { get; set; } = null!;
    }
}
