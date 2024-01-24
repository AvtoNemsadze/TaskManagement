using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities.Comment;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repository
{
    public class CommentRepository : GenericRepository<CommentEntity>, ICommentRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public CommentRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
