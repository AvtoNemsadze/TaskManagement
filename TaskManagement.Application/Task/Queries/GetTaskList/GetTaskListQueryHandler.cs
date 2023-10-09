using AutoMapper;
using MediatR;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, GetTaskListModel>
    {
        private readonly ITaskManagementDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(ITaskManagementDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<GetTaskListModel> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dbRepository.GetAllAsync<TaskEntity>(o =>
                (string.IsNullOrEmpty(request.Title) || o.Title.Contains(request.Title)) &&
                (string.IsNullOrEmpty(request.Description) || o.Description.Contains(request.Description)) &&
                (!request.DueDate.HasValue || o.DueDate == request.DueDate) &&
                (string.IsNullOrEmpty(request.Status) || o.Status == request.Status) &&
                (string.IsNullOrEmpty(request.Priority) || o.Priority == request.Priority) &&
                (string.IsNullOrEmpty(request.AttachFile) || o.AttachFile.Contains(request.AttachFile)),
                cancellationToken);

            // Map the list of tasks to the GetTaskListModel
            var taskListModel = new GetTaskListModel
            {
                Tasks = _mapper.Map<List<GetTaskDetailsModel>>(tasks)
            };

            return taskListModel;
        }
    }

}
