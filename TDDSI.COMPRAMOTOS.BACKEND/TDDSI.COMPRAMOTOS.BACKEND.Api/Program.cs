using TDDSI.COMPRAMOTOS.BACKEND.Api.Adapter;
using TDDSI.COMPRAMOTOS.BACKEND.Api.Middlewares;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Extensions;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Services;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;
using TDDSI.COMPRAMOTOS.BACKEND.Infrastructure.PostgreSql.Extensions;

WebApplicationBuilder builder = WebApplication
    .CreateBuilder( args );

builder.Configuration
    .AddJsonFile( "appsettings.json", optional: false, reloadOnChange: true )
    .AddJsonFile( $"appsettings.{builder.Environment.EnvironmentName}.json", optional: true )
    .AddEnvironmentVariables();

builder.Services
    .AddApplication( builder.Configuration )
    .AddDomainService()
    .AddInfrastructurePostgreSql( builder.Configuration );

builder.Services.AddTransient<IDispatch, Dispatch>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger( options => {
        options.SerializeAsV2 = true;
    } );
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

partial class Program {
    static void Main( string[] args ) {
        IMotoRepository motoRepository = new MotoRepositoryEnMemoria();
        MotoService motoService = new MotoService( motoRepository );
        ConsolaAdapter consola = new ConsolaAdapter( motoService );

        consola.MostrarMotos();
    }
}

public class MotoRepositoryEnMemoria : IMotoRepository {
    // Implementación de métodos de la interfaz
    public void AgregarMoto( Moto moto ) => throw new NotImplementedException();
    public List<Moto> ObtenerMotos() => throw new NotImplementedException();
}
