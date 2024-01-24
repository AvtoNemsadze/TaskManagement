using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Comment
{
    public class CreateCommentCommand : IRequest<BaseCommandResponse>
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; } = null!;
    }
}
