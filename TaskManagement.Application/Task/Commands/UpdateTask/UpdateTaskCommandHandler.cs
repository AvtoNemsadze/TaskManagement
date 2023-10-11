using AutoMapper;
using MediatR;
using TaskManagement.Application.Task.Commands.CreateTask;
using TaskManagement.Common.Exceptions;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITaskManagementDbRepository _dbRepository;

        public UpdateTaskCommandHandler(ITaskManagementDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var updateTaskModel = _mapper.Map<UpdateTaskModel>(request);

            var validator = new UpdateTaskModelValidator();
            var validationResult = await validator.ValidateAsync(updateTaskModel);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            // Retrieve the task entity from the database
            var taskEntity = await _dbRepository.GetSingleAsync<TaskEntity>(t => t.Id == request.Id && !t.IsDeleted);

            if (taskEntity == null)
            {
                throw new NotFoundException("Task", request.Id);
            }

            _mapper.Map(request, taskEntity);

            _dbRepository.Update(taskEntity);
            await _dbRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
