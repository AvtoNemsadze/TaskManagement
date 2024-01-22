using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Task.Queries.GetTaskDetails;
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

            //var taskCreatorId = team.CreateUserId;
            //if (taskCreatorId > 0)
            //{
            //    var user = await _userService.GetUser(team.CreateUserId);

            //    var teamDetailsModelWithUser = _mapper.Map<GetTaskDetailsModel>(team);
            //    taskDetailsModelWithUser.UserResponseModel = user;

            //    return taskDetailsModelWithUser;
            //}

            var teamDetailsModel = _mapper.Map<GetTeamDetailsModel>(team);
            return teamDetailsModel;
        }
    }
}
