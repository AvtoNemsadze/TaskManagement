using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Common.Exceptions;
using TaskStatus = TaskManagement.Common.Enums.TaskStatusEnum;

namespace TaskManagement.Application.Task.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTaskModelValidator();

            var validationResult = await validator.ValidateAsync(request.UpdateTaskModel);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            // default deadlines
            if (request.UpdateTaskModel.DueDate == null)
            {
                request.UpdateTaskModel.DueDate = DateTime.Now.AddDays(7);
            }

            var taskEntity = await _unitOfWork.TaskRepository.GetSingleAsync(o => o.Id == request.Id && !o.IsDeleted, cancellationToken);

            if (taskEntity == null)
            {
                throw new NotFoundException("Task", request.Id);
            }

            _mapper.Map(request.UpdateTaskModel, taskEntity);

            taskEntity.UpdatedAt = DateTime.Now;
            taskEntity.TaskStatusId = (int)TaskStatus.InProgress;

            _unitOfWork.TaskRepository.Update(taskEntity);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
