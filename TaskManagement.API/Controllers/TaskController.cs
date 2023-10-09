﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Application.Task.Queries.GetTaskList;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]

    //[Route("api/[controller]")]
    //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
    //[ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    //[ProducesResponseType(typeof(string), StatusCodes.Status415UnsupportedMediaType)]
    //[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TaskController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> CreateTask([FromForm] CreateTaskModel taskModel)
        {
            var mapTaskModel = _mapper.Map<CreateTaskCommand>(taskModel);

            var response = await _mediator.Send(mapTaskModel);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskDetailsModel>> GetTaskDetails([FromRoute] int id)
        {
            var task = await _mediator.Send(new GetTaskDetailsQuery { TaskId = id });
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTaskListModel>>> GetAllTasks()
        {
            var tasks = await _mediator.Send(new GetTaskListQuery());
            return Ok(tasks);
        }
    }
}
