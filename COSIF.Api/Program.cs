using COSIF.Application.Services;
using COSIF.Infrastructure.Repositories;
using COSIF.Domain.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


AppContext.SetSwitch("System.Net.Security.EncryptDefault", false);
AppContext.SetSwitch("Microsoft.Data.SqlClient.TrustServerCertificate", true);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "COSIF API",
        Version = "v1",
        Description = "API COSIF"
    });
});

var conn = builder.Configuration.GetConnectionString("COSIF")
           ?? "Server=(localdb)\\MSSQLLocalDB;Database=COSIF;Trusted_Connection=True;TrustServerCertificate=True;";

builder.Services.AddScoped<IMovimentoService, MovimentoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICosifService, CosifService>();

builder.Services.AddScoped<IMovimentoRepository>(_ => new MovimentoRepository(conn));
builder.Services.AddScoped<IProdutoRepository>(_ => new ProdutoRepository(conn));
builder.Services.AddScoped<IProdutoCosifRepository>(_ => new ProdutoCosifRepository(conn));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "COSIF API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();