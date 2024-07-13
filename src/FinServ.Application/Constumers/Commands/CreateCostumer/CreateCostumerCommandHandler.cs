using FinServ.Application.Abstractions.Messaging;
using FinServ.Domain.Shared;

namespace FinServ.Application.Costumers.Commands.CreateCostumerCommand;

internal sealed class CreateCostumerCommandHandler : ICommandHandler<CreateCostumerCommand>
{
    public Task<Result> Handle(CreateCostumerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
