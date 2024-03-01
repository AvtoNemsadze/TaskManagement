using TaskManagement.Domain.Entities.Comment;

namespace TaskManagement.Domain.Entities.Task
{
    public class TaskEntity : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskPriorityId { get; set; } 
        public int TaskLevelId { get; set; }
        public string? AttachFile { get; set; }
        public bool IsDuplicated { get; set; }

        public virtual TaskLevelEntity TaskLevelEntity { get; set; } = null!;
        public virtual TaskPriorityEntity TaskPriorityEntity { get; set; } = null!;
        public virtual TaskStatusEntity TaskStatusEntity { get; set; } = null!;
        public virtual ICollection<CommentEntity>? Comments { get; set; }
    }
}