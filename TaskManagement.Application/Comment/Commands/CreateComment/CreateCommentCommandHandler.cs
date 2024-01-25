using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Responses;
using TaskManagement.Common.Exceptions;
using TaskManagement.Domain.Entities.Comment;

namespace TaskManagement.Application.Comment.Commands.CreateCommentCommand
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IUserService _userService;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<BaseCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.UserExistAsync(request.UserId);
            if (!user)
            {
                throw new NotFoundException("User", request.UserId);
            }

            var task = await _unitOfWork.TaskRepository.Exists(request.TaskId);
            if (!task)
            {
                throw new NotFoundException("Task", request.TaskId);
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
