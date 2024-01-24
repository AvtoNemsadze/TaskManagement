using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Comment;
using TaskManagement.Application.Contracts.Interfaces;
using TaskManagement.Application.Team.Commands.CreateTeam;
using TaskManagement.Domain.Entities.Comment;

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

    }
}
