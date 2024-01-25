using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Comment.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; } = null!;
    }
}
