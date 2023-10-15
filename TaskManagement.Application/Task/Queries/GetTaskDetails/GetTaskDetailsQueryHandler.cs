//using AutoMapper;
//using MediatR;
//using System.Security.Cryptography.Xml;
//using TaskManagement.Application.Task.Queries.GetTaskList;
//using TaskManagement.Common.Exceptions;
//using TaskManagement.Common.Interfaces.Repositories;
//using TaskManagement.Domain.Entities;

//namespace TaskManagement.Application.Task.Queries.GetTaskDetails
//{
//    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, GetTaskDetailsModel>
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;

//        public GetTaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<GetTaskDetailsModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
//        {
//            var taskEntity = await _unitOfWork.TaskRepository.GetSingleAsync<TaskEntity>(o => o.Id == request.TaskId && !o.IsDeleted, cancellationToken);

//            if (taskEntity == null)
//            {
//                throw new NotFoundException("Task", request.TaskId);
//            }

//            var taskDetailsModel = _mapper.Map<GetTaskDetailsModel>(taskEntity);

//            return taskDetailsModel;
//        }
//    }
//}
