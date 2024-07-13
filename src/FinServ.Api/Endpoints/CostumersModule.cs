using FinServ.Application.Costumers.Commands.CreateCostumerCommand;
using FinServ.Domain.Shared;
using MediatR;

namespace FinServ.Api.Endpoints;

public static class CostumersModule
{
    public static void AddCostumersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/costumers", async (
            CreateCostumerCommand request,
            ISender sender,
            CancellationToken cancellationToken) =>
            {
                Result result = await sender.Send(request, cancellationToken);

                return result.IsSuccess
                    ? Results.Created()
                    : Results.BadRequest(result.Error.Description);
            }
        ).WithTags(Tags.Costumers);
    }
}
