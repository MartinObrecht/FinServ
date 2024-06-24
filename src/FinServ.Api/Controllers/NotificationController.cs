using FinServ.Application.Handlers.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(IMediator mediator, ILogger<NotificationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("ProdutosExpiracaoHoje")]
        public async Task<IActionResult> ProdutoExpiryEmailNotification([FromBody] ProdutoExpiryEmailNotificationRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.CodigoRetorno == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

    }
}
