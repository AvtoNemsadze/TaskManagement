using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Responses;
using TaskManagement.Application.Translation.Language;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> AddContent(AddContentRequestDto request)
        {
            var validator = new AddContentRequestDtoValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var command = new AddContentCommand
            {
                Key = request.Key,
                Translations = request.Translations
            };

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
