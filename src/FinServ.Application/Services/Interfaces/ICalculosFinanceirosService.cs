namespace FinServ.Application.Services.Interfaces
{
    public interface ICalculosFinanceirosService
    {
        Task<double> CalcularRentabilidadeAtivo(double TaxaJurosMes, double valorCompra, DateTime dataVencimento);
        Task<double> CalcularValorAtualAtivo(double rentabilidade, double valorCompra);
        Task<double> CalcularValorPatrimonio();
    }
}
