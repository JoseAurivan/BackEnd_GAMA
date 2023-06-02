using API_GAMA;
using Core;
using Core.Repository;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCidadaoAdapter();
builder.Services.AddChamadoAdapter();
builder.Services.AddCestaBasicaAdpater();
builder.Services.AddCargoAdapter();
builder.Services.AddEnderecoAdapter();
builder.Services.AddFamiliaAdapter();
builder.Services.AddReclamacaoAdapter();
builder.Services.AddSecretariaAdapter();
builder.Services.AddServidorAdapter();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
