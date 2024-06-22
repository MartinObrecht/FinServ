using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Helpers;
using FinServ.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Clientes.CreateCliente
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteRequest, CreateClienteResponse>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<CreateClienteHandler> _logger;

        public CreateClienteHandler(IClienteRepository investidorRepository, ILogger<CreateClienteHandler> logger)
        {
            _clienteRepository = investidorRepository;
            _logger = logger;
        }

        public async Task<CreateClienteResponse> Handle(CreateClienteRequest request, CancellationToken cancellationToken)
        {
            bool cpfValido = CpfHelper.CpfValido(request.Cpf);

            if(!cpfValido)
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

            try
            {
                var investidorExistente = await _clienteRepository.GetClienteByCpfAsync(CpfHelper.ExtrairNumerosCpf(request.Cpf));

                if (investidorExistente != null)
                {
                    _logger.LogWarning("Tentativa de cadastro de cliente já existente: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                    return new CreateClienteResponse
                    {
                        Nome = request.Nome,
                        Cpf = request.Cpf,
                        Mensagem = "cliente já cadastrado.",
                        CodigoRetorno = StatusCodes.Status409Conflict
                    };
                }

                Cliente cliente = new Cliente(request.Nome, CpfHelper.ExtrairNumerosCpf(request.Cpf));            


                await _clienteRepository.AddClienteAsync(cliente);

                _logger.LogInformation("cliente cadastrado com sucesso: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CreateClienteResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "cliente cadastrado com sucesso.",
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
                    Mensagem = "Erro ao processar o cadastro do cliente.",
                    CodigoRetorno = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
