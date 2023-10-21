using TaskManagement.Common.Models;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListModel 
    {
        public List<GetTaskDetailsModel> Tasks { get; set; } = new List<GetTaskDetailsModel>();
        public PaginationMetadata Pagination { get; set; } = null!;
    }
}
