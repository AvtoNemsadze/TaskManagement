using AutoMapper;
using MediatR;
using TaskManagement.Common.Exceptions;
using TaskManagement.Common.Interfaces.Repositories;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, GetTaskDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTaskDetailsModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
           
            var taskEntity = await _unitOfWork.TaskRepository
                .GetSingleAsync
                (o => o.Id == request.TaskId && !o.IsDeleted, cancellationToken,
                t => t.TaskLevelEntity,
                t => t.TaskStatusEntity)
                ?? throw new NotFoundException("Task", request.TaskId);

            var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(taskEntity);

            return taskDetailsModel;
        }
    }
}
