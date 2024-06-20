using FinServ.Application.UseCases.Ativo.ConsultarAtivos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AtivoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ConsultarAtivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterAtivosAsync()
        {
            var ativos = await _mediator.Send(new ConsultaAtivosRequest());
            return Ok(ativos);
        }
    }
}
