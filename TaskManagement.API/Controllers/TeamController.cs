using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using TaskManagement.Application.Responses;
using TaskManagement.Application.Team.Commands.CreateTeam;

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
    }
}
