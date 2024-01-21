using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Responses;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Entities.Team;

namespace TaskManagement.Application.Team.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public IUserService _userService { get; set; }
        public CreateTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        public async Task<BaseCommandResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateTeamModelValidator();

            var validationResult = await validator.ValidateAsync(request.CreateTeamModel, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Team Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            // Create TeamEntity
            var newTeam = new TeamEntity
            {
                Name = request.CreateTeamModel.TeamName,
                Description = request.CreateTeamModel.TeamDescription,
            };

            await _unitOfWork.TeamRepository.Add(newTeam);
            await _unitOfWork.Save();

            // Add TeamMembersEntities
            if (request.CreateTeamModel.MemberIds != null)
            {
                foreach (var memberId in request.CreateTeamModel.MemberIds)
                {
                    var userEntity = await _userService.GetUser(memberId);

                    if (userEntity == null)
                    {
                        return new BaseCommandResponse
                        {
                            Success = false,
                            Message = "User Does not exist",
                        };
                    }

                    var newTeamMembers = new TeamMembersEntity
                    {
                        UserId = memberId,
                        TeamId = newTeam.Id
                    };

                    await _unitOfWork.TeamMembersRepository.Add(newTeamMembers);
                    await _unitOfWork.Save();
                }
            }

            return new BaseCommandResponse
            {
                Success = true,
                Message = $"Team {newTeam.Name} Created Successfully",
                Id = newTeam.Id
            };
        }
    }
}
