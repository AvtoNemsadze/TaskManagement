using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities.Task
{
    public class TaskLevelEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<TaskEntity> Tasks { get; private set; } = new List<TaskEntity>();
    }
}
