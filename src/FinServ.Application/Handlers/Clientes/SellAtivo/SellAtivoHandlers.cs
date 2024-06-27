using FinServ.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Clientes.SellAtivo
{
    public class SellAtivoHandlers : IRequestHandler<SellAtivoRequest, SellAtivoResponse>
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<SellAtivoHandlers> _logger;

        public SellAtivoHandlers(IClienteService clienteService, ILogger<SellAtivoHandlers> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        public async Task<SellAtivoResponse> Handle(SellAtivoRequest request, CancellationToken cancellationToken)
        {
            var resultService = await _clienteService.VenderAtivoAsync(request.AtivoId, request.Cpf);

            return new SellAtivoResponse
            {
                CodigoRetorno = resultService.CodigoRetorno,
                Mensagem = resultService.Mensagem
            };

        }
    }
}
