using FinServ.Application.Models.Results;
using FinServ.Application.Services.Interfaces;
using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace FinServ.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IAtivoRepository _ativoRepository;

        public ClienteService(IClienteRepository clienteRepository, IProdutoRepository produtoRepository, IAtivoRepository ativoRepository)
        {
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _ativoRepository = ativoRepository;
        }

        public async Task<BaseResult> ComprarAtivoAsync(int idCliente, int codigoProduto, double valorCompra, int quantidade)
        {      
            var cliente = await _clienteRepository.GetByIdAsync(idCliente);

            if (cliente == null)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Cliente não encontrado."
                };
            }

            var produto = await _produtoRepository.GetByIdAsync(codigoProduto);

            if (produto == null)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            if (valorCompra < produto.Valor)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status400BadRequest,
                    Mensagem = "O valor de compra não pode ser menor que o valor do produto."
                };
            }

            var ativo = new Ativo
            {
                ClienteId = idCliente,
                ProdutoId = codigoProduto,
                ValorCompra = valorCompra,
                Quantidade = quantidade,
                DataCompra = DateTime.Now
            };


            await _ativoRepository.AddAsync(ativo);

            return new BaseResult { CodigoRetorno = StatusCodes.Status201Created, Mensagem = "Ativo comprado com sucesso!"};
        }

        public Task<BaseResult> VenderAtivoAsync(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
