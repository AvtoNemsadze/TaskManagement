using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Responses;
using TaskManagement.Domain.Entities.Comment;

namespace TaskManagement.Application.Comment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public IUserService _userService { get; set; }
        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<BaseCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = _userService.GetUser(request.UserId);
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var task = _unitOfWork.TaskRepository.GetTaskWithDetailsAsync(request.TaskId, cancellationToken);
            if(task == null) 
            {
                throw new ArgumentNullException(nameof(task));
            }

            var comment = new CommentEntity
            {
                TaskId = request.TaskId,
                UserId = request.UserId,
                Comment = request.Comment
            };

            await _unitOfWork.CommentRepository.Add(comment);
            await _unitOfWork.Save();

            return new BaseCommandResponse
            {
                Id = comment.Id,
                Message = "Comment added successfully",
                Success = true,
            };
        }
    }
}
