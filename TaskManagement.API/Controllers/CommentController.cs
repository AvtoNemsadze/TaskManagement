using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Comment.Commands.CreateComment;
using TaskManagement.Application.Comment.Commands.UpdateComment;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CommentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentModel requestModel)
        {
            var comment = new CreateCommentCommand
            {
                TaskId = requestModel.TaskId,
                UserId = requestModel.UserId,
                Comment = requestModel.Comment,
            };

            var response = await _mediator.Send(comment);

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(int id, [FromForm] string commentText)
        {
            var command = new UpdateCommentCommand 
            {
                CommentId = id,
                CommentText = commentText
            };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
