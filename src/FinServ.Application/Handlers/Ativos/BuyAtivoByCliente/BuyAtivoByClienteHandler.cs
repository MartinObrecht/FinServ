using FinServ.Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Ativos.BuyAtivoByCliente
{
    public class BuyAtivoByClienteHandler : IRequestHandler<BuyAtivoByClienteRequest, BuyAtivoByClienteResponse>
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<BuyAtivoByClienteHandler> _logger;

        public BuyAtivoByClienteHandler(IClienteService clienteService, ILogger<BuyAtivoByClienteHandler> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        public async Task<BuyAtivoByClienteResponse> Handle(BuyAtivoByClienteRequest request, CancellationToken cancellationToken)
        {
            var resultService = await _clienteService.ComprarAtivoAsync(request.IdCliente, request.CodigoProduto, request.ValorCompra, request.Quantidade);

            return new BuyAtivoByClienteResponse
            {
                CodigoRetorno = resultService.CodigoRetorno,
                Mensagem = resultService.Mensagem
            };            
        }
    }
}
