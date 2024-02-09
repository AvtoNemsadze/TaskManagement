using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Translation;
using TaskManagement.Common.Exceptions;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, GetTaskDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly LanguageService _lanuageService;

        public GetTaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService, LanguageService lanuageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _lanuageService = lanuageService ?? throw new ArgumentNullException(nameof(lanuageService));
        }

        public async Task<GetTaskDetailsModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskRepository.GetTaskWithDetailsAsync(request.Id, cancellationToken);
            if (task == null)
            {
                throw new NotFoundException("Task", request.Id);
            }

            var languageId = await _lanuageService.GetLanguageId();

            var taskLevelName = await _unitOfWork.LanguageRepository.GetTranslatedValueAsync(task.TaskLevelEntity.TranslatedId, languageId);
            var taskStatusName = await _unitOfWork.LanguageRepository.GetTranslatedValueAsync(task.TaskStatusEntity.TranslatedId, languageId);
            var taskPriorityName = await _unitOfWork.LanguageRepository.GetTranslatedValueAsync(task.TaskPriorityEntity.TranslatedId, languageId);

            var taskCreatorId = task.CreateUserId;
            if (taskCreatorId > 0)
            {
                var user = await _userService.GetUser(task.CreateUserId);

                var taskDetailsModelWithUser = _mapper.Map<GetTaskDetailsModel>(task);
                taskDetailsModelWithUser.UserResponseModel = user;

                return taskDetailsModelWithUser;
            }

            var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(task);
                taskDetailsModel.TaskLevel.Name = taskLevelName ?? throw new ArgumentNullException(nameof(taskLevelName));
                taskDetailsModel.TaskStatus.Name = taskStatusName ?? throw new ArgumentNullException(nameof(taskLevelName));
                taskDetailsModel.TaskPriority.Name = taskPriorityName ?? throw new ArgumentNullException(nameof(taskLevelName));

            return taskDetailsModel;
        }
    }
}
