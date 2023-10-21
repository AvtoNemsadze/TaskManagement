using MediatR;
using TaskManagement.Application.Task.Queries.GetTaskList;

namespace TaskManagement.Application.Task.Queries.GetLastCreatedTaskQuery
{
    public class GetLastCreatedTaskQuery : IRequest<GetTaskDetailsModel>
    {
    }
}
