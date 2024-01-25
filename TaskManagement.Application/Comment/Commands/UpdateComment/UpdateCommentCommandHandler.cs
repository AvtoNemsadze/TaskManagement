using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Common.Exceptions;

namespace TaskManagement.Application.Comment.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.
                GetSingleAsync(o => o.Id == request.CommentId && !o.IsDeleted, cancellationToken);

            if (comment == null)
            {
                throw new NotFoundException("Comment", request.CommentId);
            }

            comment.Comment = request.CommentText;

            await _unitOfWork.CommentRepository.Update(comment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
