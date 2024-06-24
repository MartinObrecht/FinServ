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

        public async Task<BaseResult> ComprarAtivoAsync(int idCliente, int codigoProduto, int quantidade)
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

            var produto = await _produtoRepository.GetByCodigoAsync(codigoProduto);

            if (produto == null)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            if (produto.Quantidade - quantidade < 0)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status400BadRequest,
                    Mensagem = "Quantidade insuficiente em estoque."
                };
            }

            var ativo = new Ativo
            {
                ClienteId = idCliente,
                ProdutoId = produto.Id,
                ValorCompra = produto.Valor,
                Quantidade = quantidade,
                DataCompra = DateTime.Now
            };

            await _ativoRepository.AddAsync(ativo);

            produto.Quantidade -= quantidade;
            _produtoRepository.Update(produto);

            return new BaseResult 
            { 
                CodigoRetorno = StatusCodes.Status201Created, 
                Mensagem = "Ativo comprado com sucesso!"
            };
        }

        public async Task<BaseResult> VenderAtivoAsync(int IdAtivo)
        {
            var ativo = await _ativoRepository.GetByIdAsync(IdAtivo);

            if (ativo == null)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Ativo não encontrado."
                };
            }

            var produto = await _produtoRepository.GetByIdAsync(ativo.ProdutoId);
            if (produto == null) {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            produto.Quantidade += ativo.Quantidade;

            _produtoRepository.Update(produto);
            await _ativoRepository.DeleteAsync(ativo);

            return new BaseResult
            {
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Ativo vendido com sucesso!"
            };           

        }
    }
}
