using FinServ.Domain.Interfaces.Produtos;

namespace FinServ.Domain.Entities.Produtos
{
    public class TipoProduto : ITipoProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CodigoProduto { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
