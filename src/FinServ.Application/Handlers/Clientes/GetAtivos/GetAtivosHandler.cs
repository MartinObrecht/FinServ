using FinServ.Application.Handlers.Clientes.GetAtivos.Responses;
using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Clientes.GetAtivos
{
    public class GetAtivosHandler : IRequestHandler<GetAtivosRequest, GetAtivosResponse>
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAtivosHandler> _logger;

        public GetAtivosHandler(IUnitOfWork unitOfWork, ILogger<GetAtivosHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<GetAtivosResponse> Handle(GetAtivosRequest request, CancellationToken cancellationToken)
        {
            var ativos = await _unitOfWork.Ativos.ExtratoAtivos(request.Cpf);

            if (ativos == null || !ativos.Any())
            {
                var cliente = await _unitOfWork.Clientes.GetByCpfAsync(request.Cpf);
                return new GetAtivosResponse
                {
                    Nome = cliente.Nome,
                    Saldo = cliente.Saldo,
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Cliente não possui ativos."
                };
            }

            var response = new GetAtivosResponse 
            { 
                Nome = ativos.Select(x => x.NomeCliente).FirstOrDefault() ?? string.Empty, 
                Saldo = ativos.Select(x => x.SaldoCliente).FirstOrDefault(),
                Patrimonio = ativos.Select(x => x.ValorCompra).FirstOrDefault() * ativos.Select(x => x.Quantidade).FirstOrDefault(),
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Ativos do cliente obtidos com sucesso."
            };

            foreach (var ativo in ativos)
            {
                response.Ativos.Add(new AtivoDto
                {
                    IdAtivo = ativo.IdAtivo,
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
