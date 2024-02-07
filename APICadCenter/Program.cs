using APICadCenter.Data;
using APICadCenter.Dominio;
using APICadCenter.Repositories;
using APICadCenter.Servico;
using APICadCenter.Servico.TratamentoErros;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];

builder.Services.AddDbContext<BancoContext>(options => options.UseSqlite("Data Source=CadCenter.db"));

builder.Services.AddScoped<IValidator<Pessoa>, PessoaModelValidator>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaServico>();

builder.Services.AddScoped<IValidator<Endereco>, EnderecoModelValidator>();
builder.Services.AddScoped<IEnderecoService, EnderecoServico>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();


