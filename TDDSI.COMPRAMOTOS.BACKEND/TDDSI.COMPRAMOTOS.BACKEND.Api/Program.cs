using TDDSI.COMPRAMOTOS.BACKEND.Api.Middlewares;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Extensions;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
