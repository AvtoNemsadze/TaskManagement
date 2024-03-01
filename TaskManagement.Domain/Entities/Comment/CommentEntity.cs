using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Domain.Entities.Team;

namespace TaskManagement.Domain.Entities.Comment
{
    public class CommentEntity : BaseEntity
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; } = default!;

        public TaskEntity TaskEntity { get; set; } = default!;
    }
}
