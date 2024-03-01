using TaskManagement.Application.Task.Queries.GetTaskDetails;

namespace TaskManagement.Application.Task.Queries.GetDuplicatedTask.cs
{
    public class GetDuplicatedTaskModel
    {
        public List<GetTaskDetailsModel> Tasks { get; set; } = new List<GetTaskDetailsModel>();
    }
}
