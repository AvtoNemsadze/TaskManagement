using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Application.Task.Commands.DeleteTask;
using TaskManagement.Application.Task.Commands.UpdateTask;
using TaskManagement.Application.Task.Queries.GetTaskList;
using TaskManagement.Common.Models;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<ActionResult> CreateTask([FromForm] CreateTaskModel taskModel)
        {
            var mapCreateTask = _mapper.Map<CreateTaskCommand>(taskModel);

            var response = await _mediator.Send(mapCreateTask);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskDetailsModel>> GetTaskDetails([FromRoute] int id)
        {
            var task = await _mediator.Send(new GetTaskDetailsQuery { TaskId = id });
            return Ok(task);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetTaskListModel>>> GetAllTasks([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetTaskListQuery
            {
                PageSize = pageSize,
                PageNumber = pageNumber
            };

            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }

        [HttpDelete("{id}")]
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
            var taskDetails = await _mediator.Send(new GetTaskDetailsQuery { TaskId = taskId });

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
