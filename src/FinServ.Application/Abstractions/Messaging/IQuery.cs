using FinServ.Domain.Shared;
using MediatR;

namespace FinServ.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
