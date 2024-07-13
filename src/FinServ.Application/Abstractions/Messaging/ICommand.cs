using FinServ.Domain.Shared;
using MediatR;

namespace FinServ.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}