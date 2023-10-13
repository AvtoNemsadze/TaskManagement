using MediatR;
using TaskManagement.Common.Exceptions;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Task.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskRepository.GetSingleAsync<TaskEntity>(t => t.Id == request.TaskId);

            if (task == null)
            {
                throw new NotFoundException("Task", request.TaskId);
            }

            // Soft Delete 
            task.IsDeleted = true;
            await _unitOfWork.TaskRepository.UpdateAsync(task);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
