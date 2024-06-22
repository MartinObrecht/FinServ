﻿using FinServ.Domain.Entities.Produtos;  
namespace FinServ.Domain.Repositories.Produtos
{
    public interface IProdutoRepository
    {
        Task<Produto?> ObterPorIdAsync(int id);
        Task<Produto?> ObterPorNomeAsync(string nome);
        Task<IEnumerable<Produto>> ObterTodosAsync();
        Task CadastrarAsync(Produto Produto);
        Task CadastrarEmLoteAsync(IEnumerable<Produto?> Produtos);
        Task<IEnumerable<Produto?>> ObterPorCodigoAsync(int CodigoProduto);
        Task<IEnumerable<Produto>> ObterProdutosDisponiveisAsync();
        Task AtualizarProdutoAsync(Produto Produto);
        Task DeletarProdutoAsync(Produto Produto);
    }
}
