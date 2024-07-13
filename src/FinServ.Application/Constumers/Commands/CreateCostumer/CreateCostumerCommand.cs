using FinServ.Application.Abstractions.Messaging;

namespace FinServ.Application.Costumers.Commands.CreateCostumerCommand;

public sealed record CreateCostumerCommand(string Name, string Email) : ICommand
{

}

