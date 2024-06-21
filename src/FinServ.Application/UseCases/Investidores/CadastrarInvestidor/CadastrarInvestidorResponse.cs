namespace FinServ.Application.UseCases.Investidores.CadastrarInvestidor
{
    public class CadastrarInvestidorResponse
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Mensagem { get; set; }
        public int CodigoRetorno { get; set; }
    }
}
