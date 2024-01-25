using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Common.Exceptions;

namespace TaskManagement.Application.Team.Queries.GetTeamDetails
{
    public class GetTeamDetailsQueryHandler : IRequestHandler<GetTeamDetailsQuery, GetTeamDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetTeamDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<GetTeamDetailsModel> Handle(GetTeamDetailsQuery request, CancellationToken cancellationToken)
        {
            var team = await _unitOfWork.TeamRepository.GetTeamWithDetailsAsync(request.Id, cancellationToken);

            if (team == null)
            {
                throw new NotFoundException("Team", request.Id);
            }

            var teamDetailsModel = _mapper.Map<GetTeamDetailsModel>(team);

            var userIds = team.TeamMembers.Select(tm => tm.UserId).ToList();

            teamDetailsModel.UserResponses = new List<UserResponseModel>();

            foreach (var userId in userIds)
            {
                var userResponse = await _userService.GetUser(userId);
                teamDetailsModel.UserResponses.Add(userResponse);
            }

            return teamDetailsModel;
        }
    }
}
