using FinServ.Application.Handlers.Ativos.GetAtivosByCliente;
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

        [HttpGet("GetByCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAtivosByClienteResponse>>> GetByClienteAsync([FromQuery]GetAtivosByClienteRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Any())
            {
                return NotFound();
            }
            return Ok(response);

        }
    }
}
