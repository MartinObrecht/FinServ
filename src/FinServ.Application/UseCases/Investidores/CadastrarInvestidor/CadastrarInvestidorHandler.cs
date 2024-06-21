using FinServ.Domain.Entities.Clientes;
using FinServ.Domain.Entities.Helpers;
using FinServ.Domain.Repositories.Investidores;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FinServ.Application.UseCases.Investidores.CadastrarInvestidor
{
    public class CadastrarInvestidorHandler : IRequestHandler<CadastrarInvestidorRequest, CadastrarInvestidorResponse>
    {
        private readonly IInvestidorRepository _investidorRepository;
        private readonly ILogger<CadastrarInvestidorHandler> _logger;

        public CadastrarInvestidorHandler(IInvestidorRepository investidorRepository, ILogger<CadastrarInvestidorHandler> logger)
        {
            _investidorRepository = investidorRepository;
            _logger = logger;
        }

        public async Task<CadastrarInvestidorResponse> Handle(CadastrarInvestidorRequest request, CancellationToken cancellationToken)
        {
            bool cpfValido = CpfHelper.CpfValido(request.Cpf);

            if(!cpfValido)
            {
                _logger.LogWarning("Tentativa de cadastro com CPF inválido: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CadastrarInvestidorResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "CPF inválido.",
                    CodigoRetorno = StatusCodes.Status400BadRequest
                };
            }

            try
            {
                var investidorExistente = await _investidorRepository.ObterPorCpfAsync(CpfHelper.ExtrairNumerosCpf(request.Cpf));

                if (investidorExistente != null)
                {
                    _logger.LogWarning("Tentativa de cadastro de investidor já existente: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                    return new CadastrarInvestidorResponse
                    {
                        Nome = request.Nome,
                        Cpf = request.Cpf,
                        Mensagem = "Investidor já cadastrado.",
                        CodigoRetorno = StatusCodes.Status409Conflict
                    };
                }

                Investidor investidor = new Investidor(request.Nome, CpfHelper.ExtrairNumerosCpf(request.Cpf));            


                await _investidorRepository.Cadastrar(investidor);

                _logger.LogInformation("Investidor cadastrado com sucesso: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CadastrarInvestidorResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "Investidor cadastrado com sucesso.",
                    CodigoRetorno = StatusCodes.Status201Created
                };
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exceção ao tentar registrar o investidor: Nome {Nome}, CPF {Cpf}", request.Nome, request.Cpf);
                return new CadastrarInvestidorResponse
                {
                    Nome = request.Nome,
                    Cpf = request.Cpf,
                    Mensagem = "Erro ao processar o cadastro do investidor.",
                    CodigoRetorno = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
