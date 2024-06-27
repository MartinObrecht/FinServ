using FinServ.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Clientes.BuyAtivo
{
    public class BuyAtivoHandler : IRequestHandler<BuyAtivoRequest, BuyAtivoResponse>
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<BuyAtivoHandler> _logger;

        public BuyAtivoHandler(IClienteService clienteService, ILogger<BuyAtivoHandler> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        public async Task<BuyAtivoResponse> Handle(BuyAtivoRequest request, CancellationToken cancellationToken)
        {
            var resultService = await _clienteService.ComprarAtivoAsync(request.Cpf, request.IdProduto, request.Quantidade);

            return new BuyAtivoResponse
            {
                CodigoRetorno = resultService.CodigoRetorno,
                Mensagem = resultService.Mensagem
            };
        }
    }
}
