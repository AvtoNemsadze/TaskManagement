﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Application.Responses;
using TaskStatus = TaskManagement.Common.Enums.TaskStatusEnum;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Task.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var createTaskModel = _mapper.Map<CreateTaskModel>(request);

            var validator = new CreateTaskModelValidator();

            var validationResult = await validator.ValidateAsync(createTaskModel, cancellationToken);

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
            var taskStatus = (int)TaskStatus.Started;

            // default deadlines
            if (request.CreateTaskModel.DueDate == null)
            {
                request.CreateTaskModel.DueDate = DateTime.Now.AddDays(7);
            }

            // upload file
            string? fileToSave = null;

            if (request.CreateTaskModel.File != null && request.CreateTaskModel.File.Length > 0)
            {
                fileToSave = await SaveFileAsync(request.CreateTaskModel.File);
            }

            var newTask = new TaskEntity
            {
                Title = request.CreateTaskModel.Title,
                Description = request.CreateTaskModel.Description,
                DueDate = request.CreateTaskModel.DueDate,
                TaskStatusId = taskStatus,
                TaskLevelId = request.CreateTaskModel.TaskLevelId,
                TaskPriorityId = request.CreateTaskModel.TaskPriorityId,
                AttachFile = fileToSave,
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

        private static async Task<string> SaveFileAsync(IFormFile? file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "File cannot be null.");
            }

            string baseDirectory = "Documents";
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(baseDirectory, uniqueFileName);

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
