using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Ativos.GetAtivoById
{
    public class GetAtivoByIdHandler : IRequestHandler<GetAtivoByIdRequest, GetAtivoByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAtivoByIdHandler> _logger;
        public GetAtivoByIdHandler(IUnitOfWork unitOfWork, ILogger<GetAtivoByIdHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<GetAtivoByIdResponse> Handle(GetAtivoByIdRequest request, CancellationToken cancellationToken)
        {
            var ativo = await _unitOfWork.Ativos.GetByIdAsync(request.IdAtivo);
            
            if (ativo == null)
            {
                _logger.LogWarning("Ativo não encontrado: {IdAtivo}", request.IdAtivo);
                return new GetAtivoByIdResponse
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Ativo não encontrado."
                };
            }
            return new GetAtivoByIdResponse
            {
                IdAtivo = ativo.Id,             
                ValorCompra = ativo.ValorCompra,
                DataCompra = ativo.DataCompra.ToShortDateString(),
                Quantidade = ativo.Quantidade,
                IdCliente = ativo.ClienteId,
                IdProduto = ativo.ProdutoId,
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Ativo encontrado."
            };
        }
    }
}
