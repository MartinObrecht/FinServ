using System.Text.Json.Serialization;

namespace FinServ.Application.Models.Results
{
    public class BaseResult
    {
        public string Mensagem { get; set; }
        [JsonIgnore]
        public int CodigoRetorno { get; set; }
    }
}
