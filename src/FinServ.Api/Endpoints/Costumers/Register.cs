using FinServ.Application.Costumers.Commands.CreateCostumerCommand;
using FinServ.Domain.Shared;
using MediatR;

namespace FinServ.Api.Endpoints.Costumers;

public class Register : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        // app.MapPost("costumers", async (
        //     CreateCostumerCommand request,
        //     ISender sender,
        //     CancellationToken cancellationToken) =>
        //     {
        //         Result<Guid> result = await sender.Send(request, cancellationToken);
        //         return result.Match(
        //             success => Results.Created($"costumers/{success.Value}", success.Value),
        //             failure => Results.BadRequest(failure.Message)
        //         );
        //     }
        // ).WithTags(Tags.Costumers);
    }
}
