using FinServ.Api.Endpoints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace FinServ.Api.Extensions;

public static class EndpointsExtension
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assemby)
    {
        ServiceDescriptor[] endpointServiceDescriptor = assemby
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                            type.IsAssignableFrom(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(endpointServiceDescriptor);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        IEnumerable<IEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (IEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }

        return app;
    }
}
