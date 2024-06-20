using FinServ.Application.UseCases.Ativo.ConsultarAtivos;
using FinServ.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace FinServ.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(ConsultaAtivosRequest)));
            //builder.Services.AddValidatorsFromAssemblyContaining<CadastraClienteRequestValidator>();
            builder.Services.AddSqlServer<FinServContext>(builder.Configuration.GetConnectionString("DefaultConnection"));


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
