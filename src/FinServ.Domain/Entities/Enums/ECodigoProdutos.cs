
using System.ComponentModel;

namespace FinServ.Domain.Entities.Enums
{
    public enum ECodigoProdutos
    {
        [Description("CDB Pré-Fixado")]
        CDBPreFixado = 100,

        [Description("CDB Pós-Fixado")]
        CDBPosFixado = 101,

        [Description("CDB Híbrido")]
        CDBHibrido = 102,

        [Description("Letra de Câmbio")]
        LC = 200,

        [Description("Letra de Crédito Imobiliário")]
        LCI = 201
    }
}
