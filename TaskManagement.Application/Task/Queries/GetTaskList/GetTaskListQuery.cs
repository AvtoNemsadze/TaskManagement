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
    }
}
