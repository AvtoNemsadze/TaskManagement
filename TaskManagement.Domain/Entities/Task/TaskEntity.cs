using TaskManagement.Domain.Entities.Comment;
using TaskStatus = TaskManagement.Common.Enums.TaskStatusEnum;

namespace TaskManagement.Domain.Entities.Task
{
    public class TaskEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
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


        public TaskEntity(string title, string? description, DateTime? dueDate, int taskLevelId, int taskPriorityId, string? attachFile)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            TaskStatusId = (int)TaskStatus.Started;
            TaskLevelId = taskLevelId;
            TaskPriorityId = taskPriorityId;
            AttachFile = attachFile;
            IsDuplicated = false;
        }

        public TaskEntity() { }
    }
}