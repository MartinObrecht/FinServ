using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Helpers;
using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.Handlers.Clientes.CreateCliente
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteRequest, CreateClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<CreateClienteHandler> _logger;

        public CreateClienteHandler(IClienteRepository clienteRepository, ILogger<CreateClienteHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        public async Task<CreateClienteResponse> Handle(CreateClienteRequest request, CancellationToken cancellationToken)
        {
            if (!CpfHelper.CpfValido(request.Cpf))
            {
                _logger.LogWarning("Tentativa de cadastro com CPF inválido: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CreateClienteResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "CPF inválido.",
                    CodigoRetorno = StatusCodes.Status400BadRequest
                };
            }

            var clienteExistente = await _clienteRepository.GetByCpfAsync(CpfHelper.ExtrairNumerosCpf(request.Cpf));
            if (clienteExistente != null)
            {
                _logger.LogWarning("Tentativa de cadastro de cliente já existente: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CreateClienteResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "Cliente já cadastrado.",
                    CodigoRetorno = StatusCodes.Status409Conflict
                };
            }

            try
            {
                Cliente cliente = new Cliente(request.Nome, CpfHelper.ExtrairNumerosCpf(request.Cpf), request.Saldo);
                await _clienteRepository.AddAsync(cliente);

                _logger.LogInformation("Cliente cadastrado com sucesso: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CreateClienteResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "Cliente cadastrado com sucesso.",
                    CodigoRetorno = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exceção ao tentar registrar o cliente: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CreateClienteResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "Erro ao processar o cadastro do cliente. Por favor, tente novamente mais tarde.",
                    CodigoRetorno = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
