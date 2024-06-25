using FinServ.Application.Handlers.Ativos.GetAtivoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AtivosController> _logger;

        public AtivosController(IMediator mediator, ILogger<AtivosController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("Obter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
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
