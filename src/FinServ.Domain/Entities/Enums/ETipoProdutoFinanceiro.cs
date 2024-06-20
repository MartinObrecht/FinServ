using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinServ.Domain.Entities.Enums
{
    public enum ETipoProdutoFinanceiro
    {
        [Description("CDB")]
        CDB = 0,

        [Description("LCI")]
        LCI = 1,

        [Description("LCA")]
        LCA = 2,

        [Description("LC")]
        LC = 3,
        
        [Description("Debentures")]
        Debentures = 4,

        [Description("CRI")]
        CRI = 5,

        [Description("CRA")]
        CRA = 6
    }
}
