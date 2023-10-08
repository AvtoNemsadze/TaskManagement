using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Task.Commands.CreateTask;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status415UnsupportedMediaType)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TaskController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost(nameof(CreateTask))]
        public async Task<ActionResult> CreateTask([FromForm] CreateTaskModel taskModel)
        {
            var mapTaskModel = _mapper.Map<CreateTaskCommand>(taskModel);

            var response = await _mediator.Send(mapTaskModel);

            return Ok(response);
        }
    }
}
