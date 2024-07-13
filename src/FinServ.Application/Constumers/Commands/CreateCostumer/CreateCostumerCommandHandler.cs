using FinServ.Application.Abstractions.Messaging;
using FinServ.Domain.Shared;

namespace FinServ.Application.Costumers.Commands.CreateCostumerCommand;

internal sealed class CreateCostumerCommandHandler : ICommandHandler<CreateCostumerCommand>
{
    public async Task<Result> Handle(CreateCostumerCommand request, CancellationToken cancellationToken)
    {
        Result result = Result.Success();

        return result;
    }
}
