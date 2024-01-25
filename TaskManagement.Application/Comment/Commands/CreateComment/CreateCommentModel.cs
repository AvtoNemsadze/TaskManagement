using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Comment.Commands.CreateCommentCommand
{
    public class CreateCommentModel
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; } = null!;
    }
}
