using Microsoft.AspNetCore.Http;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }
        public IFormFile? File { get; set; }
    }
}
