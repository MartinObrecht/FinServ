using System.ComponentModel;

namespace FinServ.Domain.Entities.Enums
{
    public enum ETipoProdutoFinanceiro
    {
        [Description("CDB-Pre-Fixado")]
        CDB_PRE_FIXADO = 101,

        [Description("CDB-Pos-Fixado")]
        CDB_POS_FIXADO = 102,

        [Description("CDB-Hibrido")]
        CDB_HIBRIDO = 103,
    }
}
