using MediatR;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<GetTaskDetailsModel>
    {
        public int TaskId { get; set; }
    }
}
