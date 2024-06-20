using FinServ.Domain.Interfaces.ProdutosFinanceiros;

namespace FinServ.Domain.Entities.ProdutosFinanceiros
{
    public class TipoProdutoFinanceiro : ITipoProdutoFinanceiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool ProdutoValido(ITipoProdutoFinanceiro tipoProdutoFinanceiro)
        {
            throw new NotImplementedException();
        }
    }
}
