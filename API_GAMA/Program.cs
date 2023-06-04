using API_GAMA;
using Core;
using Core.Repository;
using Core.Services;
using Core.Services.Interfaces;
using Infrastructure;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



builder.Services.AddDbContext<Context>();
builder.Services.AddCidadaoAdapter();
builder.Services.AddChamadoAdapter();
builder.Services.AddCestaBasicaAdpater();
builder.Services.AddCargoAdapter();
builder.Services.AddEnderecoAdapter();
builder.Services.AddFamiliaAdapter();
builder.Services.AddReclamacaoAdapter();
builder.Services.AddSecretariaAdapter();
builder.Services.AddServidorAdapter();

builder.Services.AddHttpClient();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


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



app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
