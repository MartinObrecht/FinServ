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

    }
}
