using AutoMapper;
using MediatR;
using System.Security.Cryptography.Xml;
using TaskManagement.Application.Task.Queries.GetTaskList;
using TaskManagement.Common.Exceptions;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, GetTaskDetailsModel>
    {
        private readonly ITaskManagementDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(ITaskManagementDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<GetTaskDetailsModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var taskEntity = await _dbRepository.GetSingleAsync<TaskEntity>(o => o.Id == request.TaskId && !o.IsDeleted, cancellationToken);

            if (taskEntity == null)
            {
                throw new NotFoundException("Task", request.TaskId);
            }

            var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(taskEntity);

            return taskDetailsModel;
        }
    }
}
