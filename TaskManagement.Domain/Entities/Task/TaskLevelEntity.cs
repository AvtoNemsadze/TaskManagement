using TaskManagement.Domain.Entities.Language;

namespace TaskManagement.Domain.Entities.Task
{
    public class TaskLevelEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int TranslatedId { get; set; } // ContentId

        public ICollection<ContentEntity> Content { get; set; } = default!;
        public virtual ICollection<TaskEntity> Tasks { get; private set; } = new List<TaskEntity>();
    }
}
