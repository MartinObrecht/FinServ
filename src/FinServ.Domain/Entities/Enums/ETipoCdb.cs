using System.ComponentModel;

namespace FinServ.Domain.Entities.Enums
{
    public enum ETipoCdb
    {
        [Description("Pós-fixado")]
        PosFixado = 1,

        [Description("Pré-fixado")]
        PreFixado = 2,

        [Description("Híbrido")]
        Híbrido = 3
    }
}
