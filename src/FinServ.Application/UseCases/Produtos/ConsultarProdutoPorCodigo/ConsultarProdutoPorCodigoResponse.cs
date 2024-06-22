﻿namespace FinServ.Application.UseCases.Produtos.ConsultarProdutoPorCodigo
{
    public class ConsultarProdutoPorCodigoResponse
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public double TaxaJurosMensal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Quantidade { get; set; }
        public string TipoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int CodigoTipoProduto { get; set; }

    }
}
    