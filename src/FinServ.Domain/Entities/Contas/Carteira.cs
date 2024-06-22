using FinServ.Domain.Entities.Produtos;
using FinServ.Domain.Interfaces.Contas;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinServ.Domain.Entities.Contas
{
    public class Carteira : ICarteira
    {
        public int Id { get; set; }
        public int ContaId { get; set; }
        public Conta Conta { get; set; }
        public int AtivoId { get; set; }
        public ICollection<Ativo> Ativos { get; set; } = new List<Ativo>();
        [NotMapped]
        public double ValorPatrimonio { get; set; }

    }
}
