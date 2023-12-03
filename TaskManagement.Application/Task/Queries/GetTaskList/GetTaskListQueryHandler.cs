using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Common.Infrastructure;
using TaskManagement.Common.Interfaces.Repositories;
using TaskEntity = TaskManagement.Domain.Entities.TaskEntity;
using System.Linq.Expressions;

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
            var query = _unitOfWork.TaskRepository.GetAllQueryable()
                .Where(o =>
                    !o.IsDeleted &&
                    (string.IsNullOrEmpty(request.Title) || o.Title.Contains(request.Title)) &&
                    (string.IsNullOrEmpty(request.Description) || o.Description.Contains(request.Description)) &&
                    (!request.DueDate.HasValue || o.DueDate == request.DueDate) &&
                    (string.IsNullOrEmpty(request.Status) || o.Status == request.Status) &&
                    (string.IsNullOrEmpty(request.Priority) || o.Priority == request.Priority) &&
                    (string.IsNullOrEmpty(request.AttachFile) || o.AttachFile.Contains(request.AttachFile)));

            var totalItemCount = await query.CountAsync(cancellationToken);

            // Add date filtering
            if (request.StartDate.HasValue && request.EndDate.HasValue)
            {
                query = query.Where(o => o.CreatedAt >= request.StartDate && o.CreatedAt <= request.EndDate);
            }

            // Add search functionality
            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                var searchQuery = request.SearchQuery.Trim();
                query = query.Where(o =>
                    o.Title.Contains(searchQuery) ||
                    (o.Description != null && o.Description.Contains(searchQuery))
                );
            }

            //  pagination
            var paginationHelper = new PaginationHelper<TaskEntity>();
            var (tasks, metadata) = await paginationHelper.PaginateAsync(
                query,
                request.PageNumber,
                request.PageSize,
                cancellationToken
            );

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
