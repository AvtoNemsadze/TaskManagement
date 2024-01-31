using TaskManagement.Domain.Entities.Comment;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ICommentRepository : IGenericRepository<CommentEntity>
    {
    }
}
