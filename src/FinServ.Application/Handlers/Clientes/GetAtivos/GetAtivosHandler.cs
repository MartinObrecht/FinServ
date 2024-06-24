using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosHandler : IRequestHandler<GetAtivosRequest, IList<GetAtivosResponse>>
    {
        private readonly IAtivoRepository _ativoRepository;
        private readonly ILogger<GetAtivosHandler> _logger;

        public GetAtivosHandler(IAtivoRepository ativoRepository, ILogger<GetAtivosHandler> logger)
        {
            _ativoRepository = ativoRepository;
            _logger = logger;
        }

        public async Task<IList<GetAtivosResponse>> Handle(GetAtivosRequest request, CancellationToken cancellationToken)
        {
            var ativos = await _ativoRepository.GetAtivos(request.ClienteId);

            var response = new List<GetAtivosResponse>();
            foreach (var ativo in ativos)
            {
                response.Add(new GetAtivosResponse
                {
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
