using MediatR;
using TaskManagement.Application.Team.Queries.GetTeamDetails;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<GetTaskDetailsModel>
    {
        public int Id { get; set; }
    }
}
