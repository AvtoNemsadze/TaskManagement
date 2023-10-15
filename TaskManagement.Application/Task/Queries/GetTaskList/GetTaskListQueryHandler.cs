//using AutoMapper;
//using MediatR;
//using TaskManagement.Common.Interfaces.Repositories;
//using TaskManagement.Domain.Entities;

//namespace TaskManagement.Application.Task.Queries.GetTaskList
//{
//    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, GetTaskListModel>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;

//        public GetTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<GetTaskListModel> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
//        {
//            var tasks = await _unitOfWork.TaskRepository.GetAll<TaskEntity>(o =>
//             !o.IsDeleted &&
//             (string.IsNullOrEmpty(request.Title) || o.Title.Contains(request.Title)) &&
//             (string.IsNullOrEmpty(request.Description) || o.Description.Contains(request.Description)) &&
//             (!request.DueDate.HasValue || o.DueDate == request.DueDate) &&
//             (string.IsNullOrEmpty(request.Status) || o.Status == request.Status) &&
//             (string.IsNullOrEmpty(request.Priority) || o.Priority == request.Priority) &&
//             (string.IsNullOrEmpty(request.AttachFile) || o.AttachFile.Contains(request.AttachFile)),
//             cancellationToken);


//            var taskListModel = new GetTaskListModel
//            {
//                Tasks = _mapper.Map<List<GetTaskDetailsModel>>(tasks)
//            };

//            return taskListModel;
//        }
//    }

//}
