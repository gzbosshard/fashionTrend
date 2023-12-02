using fashionTrend.API.Extensions;
using fashionTrend.Application.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace fashionTrend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Configurando nossa camada de persistencia
            builder.Services.ConfigurePersistenceApp(builder.Configuration);
            // Registrar os servi�os relacionado a camada de aplica��o
            // auto mapper, mediator, fluent id
            builder.Services.ConfigureApplicationApp();
            builder.Services.ConfigureCorsPolicy();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => {
                var openApiInfo = new OpenApiInfo();

                openApiInfo.Title = "FashionTrend Sustentabilidade";
                openApiInfo.Description = "Servi�os para contra��o de servi�os de costura";
                openApiInfo.License = new OpenApiLicense
                {
                    Name = "FashionTrend Sustentabilidade"
                };
                openApiInfo.Contact = new OpenApiContact()
                {
                    Name = "Equipe Sustentabilidade"
                };

                options.SwaggerDoc("v1", openApiInfo);

            });

            var app = builder.Build();

         

            // Esse m�todo precisamos criar na m�o para subir nosso BD a nossa aplica��o
            BD.BD.CreateDatabase(app);

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors();
            app.MapControllers();
            app.Run();
        }
    }
}