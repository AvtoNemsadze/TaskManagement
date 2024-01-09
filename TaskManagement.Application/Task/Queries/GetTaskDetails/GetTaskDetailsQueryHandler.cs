﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskManagement.Application.Constants;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Common.Exceptions;
using TaskManagement.Common.Interfaces.Repositories;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, GetTaskDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetTaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<GetTaskDetailsModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskRepository.GetTaskWithDetailsAsync(request.Id, cancellationToken);

            if (task == null)
            {
                throw new NotFoundException("Task", request.Id);
            }

            if (!string.IsNullOrEmpty(task.CreateUserId) && int.TryParse(task.CreateUserId, out int userId))
            {
                var user = await _userService.GetUser(userId);

                var taskDetailsModelWithUser = _mapper.Map<GetTaskDetailsModel>(task);
                taskDetailsModelWithUser.UserResponseModel = user;

                return taskDetailsModelWithUser;
            }
            else
            {
                var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(task);

                return taskDetailsModel;
            }
        }
    }
}
