using MediatR;
using TaskManagement.Application.Task.Queries.GetTaskDetails;

namespace TaskManagement.Application.Task.Queries.GetLastCreatedTaskQuery
{
    public class GetLastCreatedTaskQuery : IRequest<GetTaskDetailsModel>
    {
    }
}
