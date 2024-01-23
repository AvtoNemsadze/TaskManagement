using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Team.Commands.CreateTeam;
using TaskManagement.Application.Team.Commands.UpdateTeam.BlockTeamMember;
using TaskManagement.Application.Team.Commands.UpdateTeam.RemoveUserFromTeam;
using TaskManagement.Application.Team.Queries.GetTeamDetails;
using TaskManagement.Application.Team.Queries.GetTeamMembersList;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TeamController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeam([FromBody] CreateTeamModel teamModel)
        {

            var teamToCreate = _mapper.Map<CreateTeamCommand>(teamModel);

            var response = await _mediator.Send(teamToCreate);

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetTeamDetailsModel>> GetTeamDetails([FromRoute] int id)
        {
            var team = await _mediator.Send(new GetTeamDetailsQuery { Id = id });
            return Ok(team);
        }

        [HttpPut("remove-team-member")]
        public async Task<IActionResult> RemoveTeamMember(RemoveTeamMemberModel model)
        {
            var command = new RemoveTeamMemberCommand
            {
                TeamId = model.TeamId,
                UserIdToRemove = model.UserIdToRemove,
                RequestingUserId = model.RequestingUserId
            };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{teamId}/user-ids")]
        public async Task<IActionResult> GetUserIdsByTeamId(int teamId)
        {
            var query = new GetTeamMembersQuery { TeamId = teamId };
            var userIds = await _mediator.Send(query);

            return Ok(userIds);
        }

        [HttpPut("block-team-member")]
        public async Task<IActionResult> BlockTeamMember(BlockTeamMemberModel requestModel)
        {
            var validator = new BlockTeamMemberModelValidator();
            var validationResult = validator.Validate(requestModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = new BlockTeamMemberCommand
            {
               TeamId = requestModel.TeamId,
               UserIdToBlock = requestModel.UserIdToBlock,
               RequestingUserId = requestModel.RequestingUserId,
               Duration = requestModel.Duration
            };

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
