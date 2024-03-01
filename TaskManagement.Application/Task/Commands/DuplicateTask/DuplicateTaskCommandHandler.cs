using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Responses;
using TaskManagement.Common.Exceptions;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Task.Commands.DuplicateTask
{
    public class DuplicateTaskCommandHandler : IRequestHandler<DuplicateTaskCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DuplicateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DuplicateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskRepository.GetSingleAsync(x => x.Id == request.TaskId, cancellationToken);
            if(task == null)
            {
                throw new NotFoundException("task", request.TaskId);
            }

            var mapEntityToModel = _mapper.Map<DuplicateTaskModel>(task);

            var taskToDuplicate = _mapper.Map<TaskEntity>(mapEntityToModel);
                taskToDuplicate.IsDuplicated = true;

            await _unitOfWork.TaskRepository.Add(taskToDuplicate);
            await _unitOfWork.Save();

            return new BaseCommandResponse
            {
                Message = "task duplicated successfully",
                Id = taskToDuplicate.Id,
            };
        }
    }
}
