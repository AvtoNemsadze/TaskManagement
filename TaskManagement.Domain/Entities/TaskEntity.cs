namespace TaskManagement.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public string? AttachFile { get; set; } 
    }
}