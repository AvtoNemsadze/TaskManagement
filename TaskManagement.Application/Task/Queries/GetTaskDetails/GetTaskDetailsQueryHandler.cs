using AutoMapper;
using MediatR;
using TaskManagement.Common.Exceptions;
using TaskManagement.Common.Interfaces.Repositories;

namespace TaskManagement.Application.Task.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, GetTaskDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetTaskDetailsModel> Handle(GetTaskDetailsQuery request, CancellationToken cancellationToken)
        {

            var task = await _unitOfWork.TaskRepository.GetTaskWithDetailsAsync(request.Id, cancellationToken);
            
            if(task == null)
            {
                throw new NotFoundException("Task", request.Id);
            }

            return _mapper.Map<GetTaskDetailsModel>(task);
        }
    }
}
