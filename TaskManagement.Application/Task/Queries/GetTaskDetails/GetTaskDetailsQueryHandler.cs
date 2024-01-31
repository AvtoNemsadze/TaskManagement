using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskManagement.Application.Constants;
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
            // string languagePrefix = _lanuageService.GetAcceptedLanguage();

            var task = await _unitOfWork.TaskRepository.GetTaskWithDetailsAsync(request.Id, cancellationToken);

            if (task == null)
            {
                throw new NotFoundException("Task", request.Id);
            }

            var taskCreatorId = task.CreateUserId;
            if(taskCreatorId > 0)
            {
                var user = await _userService.GetUser(task.CreateUserId);

                var taskDetailsModelWithUser = _mapper.Map<GetTaskDetailsModel>(task);
                taskDetailsModelWithUser.UserResponseModel = user;

                return taskDetailsModelWithUser;
            }

            var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(task);
            return taskDetailsModel;
        }
    }
}
