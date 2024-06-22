using System.Text.Json.Serialization;

namespace FinServ.Application.Models.Responses
{
    public class ResponseBase
    {
        public string Mensagem { get; set; }
        [JsonIgnore]
        public int CodigoRetorno { get; set; }
    }
}
