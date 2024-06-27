using FinServ.Application.Models.Results;
using FinServ.Application.Services.Interfaces;
using FinServ.Domain.Entities.Ativos;
using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Helpers;
using FinServ.Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace FinServ.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResult> ComprarAtivoAsync(string cpf, int idProduto, int quantidade)
        {      
            Cliente? cliente = await _unitOfWork.Clientes.GetByCpfAsync(CpfHelper.ExtrairNumerosCpf(cpf));

            if (cliente == null)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Cliente não encontrado."
                };
            }

            var produto = await _unitOfWork.Produtos.GetByIdAsync(idProduto);

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

            if (cliente.Saldo - produto.Valor * quantidade < 0)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status400BadRequest,
                    Mensagem = "Saldo insuficiente."
                };
            }

            var ativo = new Ativo
            {
                ClienteId = cliente.Id,
                ProdutoId = produto.Id,
                ValorCompra = produto.Valor,
                Quantidade = quantidade,
                DataCompra = DateTime.Now
            };

            await _unitOfWork.Ativos.AddAsync(ativo);

            produto.Quantidade -= quantidade;
            cliente.Saldo -= produto.Valor * quantidade;
            _unitOfWork.Clientes.Update(cliente);
            _unitOfWork.Produtos.Update(produto);

            _unitOfWork.Commit();

            return new BaseResult 
            { 
                CodigoRetorno = StatusCodes.Status201Created, 
                Mensagem = "Ativo comprado com sucesso!"
            };
        }

        public async Task<BaseResult> VenderAtivoAsync(int IdAtivo, string cpf)
        {
            var ativosCliente = await _unitOfWork.Ativos.GetAtivosByCpfAsync(CpfHelper.ExtrairNumerosCpf(cpf));
            var ativo = ativosCliente.FirstOrDefault(a => a.Id == IdAtivo);


            if (ativosCliente == null)
            {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Ativo não encontrado."
                };
            }

            var produto = await _unitOfWork.Produtos.GetByIdAsync(ativosCliente.Select(x => x.ProdutoId).FirstOrDefault());
            if (produto == null) {
                return new BaseResult
                {
                    CodigoRetorno = StatusCodes.Status404NotFound,
                    Mensagem = "Produto não encontrado."
                };
            }

            produto.Quantidade += ativo.Quantidade;
            var cliente = ativosCliente.Select(x => x.Cliente).FirstOrDefault();
            cliente.Saldo += ativo.ValorCompra * ativo.Quantidade;           

            _unitOfWork.Produtos.Update(produto);
            _unitOfWork.Clientes.Update(cliente);
            _unitOfWork.Ativos.Delete(ativo);

            _unitOfWork.Commit();

            return new BaseResult
            {
                CodigoRetorno = StatusCodes.Status200OK,
                Mensagem = "Ativo vendido com sucesso!"
            };           

        }
    }
}
