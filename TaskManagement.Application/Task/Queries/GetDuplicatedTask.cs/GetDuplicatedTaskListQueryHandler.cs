using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
using TaskManagement.Application.Translation;

namespace TaskManagement.Application.Task.Queries.GetDuplicatedTask.cs
{
    public class GetDuplicatedTaskListQueryHandler : IRequestHandler<GetDuplicatedTaskListQuery, GetDuplicatedTaskModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly LanguageService _languageService;
        public GetDuplicatedTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService, LanguageService lanuageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _languageService = lanuageService;
        }

        public async Task<GetDuplicatedTaskModel> Handle(GetDuplicatedTaskListQuery requst, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.TaskRepository.GetDuplicatedTaskListWithDetailsAsync();

            var taskList = new List<GetTaskDetailsModel>();

            foreach (var task in query)
            {
                var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(task);

                // Get translated names for task level, status, and priority
                //var languageId = await _languageService.GetLanguageId();
                //var taskLevelName = await _unitOfWork.LanguageRepository.GetTranslatedValueAsync(task.TaskLevelEntity.TranslatedId, languageId);
                //var taskStatusName = await _unitOfWork.LanguageRepository.GetTranslatedValueAsync(task.TaskStatusEntity.TranslatedId, languageId);
                //var taskPriorityName = await _unitOfWork.LanguageRepository.GetTranslatedValueAsync(task.TaskPriorityEntity.TranslatedId, languageId);

                //taskDetailsModel.TaskLevel.Name = taskLevelName ?? taskDetailsModel.TaskLevel.Name;
                //taskDetailsModel.TaskStatus.Name = taskStatusName ?? taskDetailsModel.TaskStatus.Name;
                //taskDetailsModel.TaskPriority.Name = taskPriorityName ?? taskDetailsModel.TaskPriority.Name;

                if (task.CreateUserId > 0)
                {
                    var user = await _userService.GetUser(task.CreateUserId);
                    taskDetailsModel.UserResponseModel = _mapper.Map<UserResponseModel>(user);
                }

                taskList.Add(taskDetailsModel);
            }

            var taskListModel = new GetDuplicatedTaskModel
            {
                Tasks = taskList,
            };

            return taskListModel;
        }
    }
}
