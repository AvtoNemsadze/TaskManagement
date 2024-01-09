using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
using TaskManagement.Common.Helpers;
using TaskManagement.Common.Interfaces.Repositories;
using TaskEntity = TaskManagement.Domain.Entities.Task.TaskEntity;


namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, GetTaskListModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
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

            //var users = await _userService.GetAllUsers();
            //foreach (var task in taskListModel.Tasks)
            //{
            //    var userForTask = users.FirstOrDefault(user => user.Id == task.UserResponseModel?.Id);

            //    // Set the user details for each task
            //    task.UserResponseModel = userForTask;
            //}


            return taskListModel;
        }
    }
}