using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities.Comment;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ICommentRepository : IGenericRepository<CommentEntity>
    {
    }
}
