using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Common.Models;

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

            var metadata = new PaginationMetadata(totalItemCount, request.PageSize, request.PageNumber);

            // limit page size
            int maxTasksPageSize = 20;
            if (request.PageSize > maxTasksPageSize)
            {
                request.PageSize = maxTasksPageSize;
            }

            var tasks = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var taskListModel = new GetTaskListModel
            {
                Tasks = _mapper.Map<List<GetTaskDetailsModel>>(tasks),
                Pagination = metadata
            };

            return taskListModel;
        }
    }
}
