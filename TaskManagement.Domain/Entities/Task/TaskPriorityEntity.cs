using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities.Task
{
    public class TaskPriorityEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<TaskEntity> Tasks { get; private set; } = new List<TaskEntity>();
    }
}
