using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Ativos.GetAtivosByCliente
{
    public class GetAtivosByClienteHandler : IRequestHandler<GetAtivosByClienteRequest, IList<GetAtivosByClienteResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IAtivoRepository _ativoRepository;
        private readonly ILogger<GetAtivosByClienteHandler> _logger;

        public GetAtivosByClienteHandler(IMediator mediator, IAtivoRepository ativoRepository, ILogger<GetAtivosByClienteHandler> logger)
        {
            _mediator = mediator;
            _ativoRepository = ativoRepository;
            _logger = logger;
        }

        public async Task<IList<GetAtivosByClienteResponse>> Handle(GetAtivosByClienteRequest request, CancellationToken cancellationToken)
        {
            var ativos = await _ativoRepository.CreateAsync(request.ClienteId);

            var response = new List<GetAtivosByClienteResponse>();
            foreach (var ativo in ativos)
            {
                response.Add(new GetAtivosByClienteResponse
                {
                    NomeCliente = ativo.NomeCliente,
                    NomeProduto = ativo.NomeProduto,
                    DescricaoProduto = ativo.DescricaoProduto,
                    DataVencimentoProduto = ativo.DataVencimentoProduto.ToShortDateString(),
                    TaxaJurosMes = ativo.TaxaJurosMes,
                    ValorCompra = ativo.ValorCompra,
                    DataCompra = ativo.DataCompra.ToShortDateString(),
                    ValorAtual = ativo.ValorAtual,
                    Quantidade = ativo.Quantidade
                });
            }

            return response;
        }
    }
}
