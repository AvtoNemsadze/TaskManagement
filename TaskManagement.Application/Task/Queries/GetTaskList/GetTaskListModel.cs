using TaskManagement.Common.Mapping;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListModel 
    {
        public List<GetTaskDetailsModel> Tasks { get; set; } = new List<GetTaskDetailsModel>();
        public PaginationMetadata Pagination { get; set; } = null!;
    }
}
