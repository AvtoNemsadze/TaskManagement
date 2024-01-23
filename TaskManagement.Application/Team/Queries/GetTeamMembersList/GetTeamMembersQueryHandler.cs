using MediatR;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Team.Queries.GetTeamMembersList
{
    public class GetTeamMembersQueryHandler : IRequestHandler<GetTeamMembersQuery, List<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTeamMembersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<int>> Handle(GetTeamMembersQuery request, CancellationToken cancellationToken)
        {
            var userIds = await _unitOfWork.TeamMembersRepository.GetUserIdsByTeamIdAsync(request.TeamId, cancellationToken);
            return userIds;
        }
    }
}
