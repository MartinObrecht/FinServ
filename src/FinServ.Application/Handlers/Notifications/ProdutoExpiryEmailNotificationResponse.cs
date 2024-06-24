
using FinServ.Application.Models.Results;

namespace FinServ.Application.Handlers.Notifications
{
    public class ProdutoExpiryEmailNotificationResponse : BaseResult
    {
        public string Email { get; set; }
    }
}
