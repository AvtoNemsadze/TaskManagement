using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Team.Queries.GetTeamDetails
{
    public class GetTeamDetailsQuery : IRequest<GetTeamDetailsModel>
    {
        public int Id { get; set; }
    }
}
