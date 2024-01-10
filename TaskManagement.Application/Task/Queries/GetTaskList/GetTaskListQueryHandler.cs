using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
using TaskManagement.Common.Helpers;
using TaskEntity = TaskManagement.Domain.Entities.Task.TaskEntity;


namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, GetTaskListModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTaskListModel> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.TaskRepository.GetTaskListWithDetailsAsync();

            var filterExpression = new TaskListSpecification(request).GetFilterExpression();

            var filteredTasks = query.Where(filterExpression);

            var paginationHelper = new PaginationHelper<TaskEntity>();

            var (tasks, metadata) = await paginationHelper.PaginateAsync(filteredTasks, request.PageNumber, request.PageSize, cancellationToken);

            var taskListModel = new GetTaskListModel
            {
                Tasks = _mapper.Map<List<GetTaskDetailsModel>>(tasks),
                Pagination = metadata,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                SearchQuery = request.SearchQuery,
            };

            return taskListModel;
        }
    }
}