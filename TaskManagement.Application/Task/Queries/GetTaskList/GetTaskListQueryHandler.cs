using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
using TaskManagement.Common.Helpers;
using TaskEntity = TaskManagement.Domain.Entities.Task.TaskEntity;


namespace TaskManagement.Application.Task.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, GetTaskListModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IUserService _userService;

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

            var taskList = new List<GetTaskDetailsModel>();
            foreach (var task in tasks)
            {
                var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(task);

                if (task.CreateUserId > 0)
                {
                    var user = await _userService.GetUser(task.CreateUserId);
                    taskDetailsModel.UserResponseModel = _mapper.Map<UserResponseModel>(user);
                }

                taskList.Add(taskDetailsModel);
            }

            var taskListModel = new GetTaskListModel
            {
                Tasks = taskList,
                Pagination = metadata,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                SearchQuery = request.SearchQuery,
            };

            return taskListModel;
        }
    }
}