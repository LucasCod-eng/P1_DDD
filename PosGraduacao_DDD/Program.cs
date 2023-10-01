
using DDD.Infra.SQLServer;
using DDD.Infra.SQLServer.Interface;
using DDD.Infra.SQLServer.Repositorio;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//IOC - Dependency Injection
//builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorioSqlServer>();
builder.Services.AddScoped<IAvaliacaoRepositorio, AvaliacaoRepositorioSqlServer>();
builder.Services.AddScoped<SqlContext, SqlContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddControllers();

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
