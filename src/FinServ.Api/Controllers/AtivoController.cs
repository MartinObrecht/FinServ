using FinServ.Application.Handlers.Ativos.GetAtivoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AtivoController> _logger;

        public AtivoController(IMediator mediator, ILogger<AtivoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("Obter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAtivoByIdResponse>> GetByIdAsync([FromQuery]GetAtivoByIdRequest request)
        {
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
