using FinServ.Application.UseCases.Contas.CriarConta;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CriarConta")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CriarContaAsync([FromBody] CriarContaRequest request)
        {
            var response = await _mediator.Send(request);
            return Created("api/Conta/CriarConta", response);
        }
    }
}
