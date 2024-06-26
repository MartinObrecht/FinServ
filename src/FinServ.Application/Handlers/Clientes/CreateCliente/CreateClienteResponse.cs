namespace FinServ.Application.Handlers.Clientes.CreateCliente
{
    public class CreateClienteResponse
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }
        public string Mensagem { get; set; }
        public int CodigoRetorno { get; set; }
    }
}
