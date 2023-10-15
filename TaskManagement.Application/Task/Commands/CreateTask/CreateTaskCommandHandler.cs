using TaskManagement.Application.Responses;
using TaskManagement.Domain.Entities;
using TaskStatus = TaskManagement.Common.Enums.TaskStatusEnum;
using AutoMapper;
using MediatR;
using TaskManagement.Common.Interfaces.Repositories;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var createTaskModel = _mapper.Map<CreateTaskModel>(request);

            var validator = new CreateTaskModelValidator();

            var validationResult = await validator.ValidateAsync(createTaskModel);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Task Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                response = await PerformCreateTaskLogicAsync(request);
            }

            return response;
        }

        private async Task<BaseCommandResponse> PerformCreateTaskLogicAsync(CreateTaskCommand request)
        {
            var taskStatus = TaskStatus.Started.ToString();

            // default deadlines
            if (request.CreateTaskModel.DueDate == null)
            {
                request.CreateTaskModel.DueDate = DateTime.Now.AddDays(7);
            }

            var newTask = new TaskEntity
            {
                Title = request.CreateTaskModel.Title,
                Description = request.CreateTaskModel.Description,
                DueDate = request.CreateTaskModel.DueDate,
                Status = taskStatus,
                Priority = request.CreateTaskModel.Priority,
            };

            await _unitOfWork.TaskRepository.Add(newTask);
            await _unitOfWork.Save();

            var response = new BaseCommandResponse
            {
                Success = true,
                Message = "Task Created Successfully",
                Id = newTask.Id
            };

            return response;
        }
    }
}
