using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Common.Exceptions;

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
            var task = await _unitOfWork.TaskRepository.GetSingleAsync(t => t.Id == request.TaskId)
                ?? throw new NotFoundException("Task", request.TaskId);

            task.IsDeleted = true;

            await _unitOfWork.TaskRepository.Update(task);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
