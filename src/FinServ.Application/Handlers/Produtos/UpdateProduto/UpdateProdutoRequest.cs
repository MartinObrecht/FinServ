﻿using MediatR;

namespace FinServ.Application.Handlers.Produtos.UpdateProduto
{
    public class UpdateProdutoRequest : IRequest<UpdateProdutoResponse>
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int CodigoProduto { get; set; }
        public decimal TaxaJurosMensal { get; set; }
        public string DataVencimento { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
