using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Team.Queries.GetTeamMembersList
{
    public class GetTeamMembersQuery : IRequest<List<int>>
    {
        public int TeamId { get; set; }
    }
}
