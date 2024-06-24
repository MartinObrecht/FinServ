namespace FinServ.Application.Handlers.Clientes.CreateCliente
{
    public class CreateClienteResponse
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Mensagem { get; set; }
        public int CodigoRetorno { get; set; }
    }
}
