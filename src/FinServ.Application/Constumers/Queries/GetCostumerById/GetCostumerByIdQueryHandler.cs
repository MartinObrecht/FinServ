using FinServ.Application.Abstractions.Messaging;
using FinServ.Domain.Shared;

namespace FinServ.Application.Queries.GetCostumerById;

internal sealed class GetCostumerByIdQueryHandler
    : IQueryHandler<GetCostumerByIdQuery, CostumerResponse>
{
    public Task<Result<CostumerResponse>> Handle(GetCostumerByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
