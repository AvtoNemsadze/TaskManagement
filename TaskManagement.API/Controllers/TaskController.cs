﻿using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Comment.Commands.CreateComment;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Application.Task.Commands.DeleteTask;
using TaskManagement.Application.Task.Commands.DuplicateTask;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Application.Task.Queries.GetDuplicatedTask.cs;
using TaskManagement.Application.Task.Queries.GetLastCreatedTaskQuery;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
using TaskManagement.Application.Task.Queries.GetTaskList;
using TaskManagement.Application.Team.Commands.UpdateTeam.BlockTeamMember;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[Authorize]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> CreateTask([FromForm] CreateTaskModel taskModel)
        {
            var validator = new CreateTaskModelValidator();
            var validationResult = await validator.ValidateAsync(taskModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var mapCreateTask = _mapper.Map<CreateTaskCommand>(taskModel);

            var response = await _mediator.Send(mapCreateTask);

            return Ok(response);
        }

        [HttpPost("duplicateTask")]
        public async Task<IActionResult> DuplicateTask([FromQuery] int taskId)
        {
            var taskToDuplicate = new DuplicateTaskCommand { TaskId = taskId };

            var response = await _mediator.Send(taskToDuplicate);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskDetailsModel>> GetTaskDetails([FromRoute] int id)
        {
            var task = await _mediator.Send(new GetTaskDetailsQuery { Id = id });
            return Ok(task);
        }

        [HttpGet("last-created")]
        public async Task<ActionResult<GetTaskDetailsModel>> GetLastCreatedTask()
        {
            var task = await _mediator.Send(new GetLastCreatedTaskQuery());
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<GetTaskListModel>> GetAllTasks([FromQuery] TaskListQueryDto dto)
        {
            var query = new GetTaskListQuery
            {
                PageSize = dto.PageSize,
                PageNumber = dto.PageNumber,
                StartDate = dto.StartDate, 
                EndDate = dto.EndDate,
                SearchQuery = dto.SearchQuery,
                TaskLevelIds = dto.TaskLevelIds,
                TaskStatusIds = dto.TaskStatusIds,
            };

            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        [HttpGet("GetDuplicatedTaskList")]
        public async Task<ActionResult<GetDuplicatedTaskModel>> GetAllDuplicatedTasks()
        {

            var task = await _mediator.Send(new GetDuplicatedTaskListQuery());
            return Ok(task);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var command = new DeleteTaskCommand { TaskId = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromForm] UpdateTaskModel updateTaskModel)
        {
            var command = new UpdateTaskCommand { Id = id, UpdateTaskModel = updateTaskModel };
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpGet("Download/{taskId}")]
        public async Task<IActionResult> DownloadFile(int taskId)
        {
            var taskDetails = await _mediator.Send(new GetTaskDetailsQuery { Id = taskId });

            if (taskDetails == null)
            {
                return NotFound("Task not found");
            }

            var filePath = taskDetails.AttachFile;

            if (filePath == null)
            {
                return NotFound("File not found");
            }

            var fileStream = System.IO.File.OpenRead(filePath);
            var fileName = Path.GetFileName(filePath);

            return File(fileStream, "application/octet-stream", fileName);
        }
    }
}
