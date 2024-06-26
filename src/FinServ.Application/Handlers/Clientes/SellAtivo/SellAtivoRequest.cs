﻿using MediatR;

namespace FinServ.Application.Handlers.Clientes.SellAtivo
{
    public class SellAtivoRequest : IRequest<SellAtivoResponse>
    {
        public string Cpf { get; set; }
        public int AtivoId { get; set; }
    }
}
