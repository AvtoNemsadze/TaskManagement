﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
using TaskManagement.Common.Exceptions;

namespace TaskManagement.Application.Task.Queries.GetLastCreatedTaskQuery
{
    public class GetLastCreatedTaskQueryHandler : IRequestHandler<GetLastCreatedTaskQuery, GetTaskDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLastCreatedTaskQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTaskDetailsModel> Handle(GetLastCreatedTaskQuery request, CancellationToken cancellationToken)
        {
            var lastCreatedTask = await _unitOfWork.TaskRepository.GetAllQueryable()
                .Include(t => t.TaskLevelEntity)
                .Include(t => t.TaskStatusEntity)
                .Include(t => t.TaskPriorityEntity)
                .OrderByDescending(t => t.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);

            if (lastCreatedTask == null)
            {
                throw new ArgumentNullException(nameof(lastCreatedTask));
            }

            var result = _mapper.Map<GetTaskDetailsModel>(lastCreatedTask);

            return result;
        }
    }
}
