using MediatR;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskDetailsQuery : IRequest<GetTaskDetailsModel>
    {
        public int TaskId { get; set; }
    }
}
