using TaskManagement.Common.Models;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListModel 
    {
        public List<GetTaskDetailsModel> Tasks { get; set; } = new List<GetTaskDetailsModel>();
        public PaginationMetadata Pagination { get; set; } = null!;
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public string? SearchQuery { get; set; }
    }
}
