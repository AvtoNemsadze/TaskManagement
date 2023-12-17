using MediatR;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<GetTaskListModel>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public string? AttachFile { get; set; }
        public DateTime CreatedAt { get; set; }

        // pagination 
        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 10;

        // filter task list
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<int> TaskLevelIds { get; set; } = new List<int>();
        public List<int> TaskStatusIds { get; set; } = new List<int>();

        // search
        public string? SearchQuery { get; set; }

    }
}
