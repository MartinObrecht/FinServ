using FinServ.Application.Abstractions.Messaging;

namespace FinServ.Application.Queries.GetCostumerById;

public sealed record GetCostumerByIdQuery(Guid CostumerId) : IQuery<CostumerResponse>
{

}
