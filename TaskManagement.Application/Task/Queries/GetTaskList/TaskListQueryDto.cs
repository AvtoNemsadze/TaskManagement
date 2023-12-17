using System.ComponentModel;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class TaskListQueryDto
    {
        [DefaultValue(1)]
        public int PageNumber { get; set; }

        [DefaultValue(10)]
        public int PageSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? SearchQuery { get; set; }
        public List<int> TaskLevelIds { get; set; } = new List<int>();
        public List<int> TaskStatusIds { get; set; } = new List<int>();
    }
}
