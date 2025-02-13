using CreditCard.Api.Extensions;
using CreditCard.Core.Application.Behaviours;
using CreditCard.Core.Application.Features.Transaction.Commands.CreateTransactionCommand;
using CreditCard.Core.Interfaces;
using CreditCard.Infrastructure.Data;
using CreditCard.Infrastructure.Filters;
using CreditCard.Infrastructure.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(op => { op.Filters.Add<GlobalExceptionFilter>(); }).AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true);

//foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
//{
//    builder.Services.AddValidatorsFromAssembly(assembly);
//}

//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
}).AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});


// Define la cadena de conexión
string connectionString = "Server=frank2025.database.windows.net;Database=FrankTest;User Id=Administrador;Password=Admin123;TrustServerCertificate=True;";

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountStatementRepository, AccountStatementRepository>();
builder.Services.AddDependecy();

// Registra DapperContext y pasa la cadena de conexión por constructor
builder.Services.AddSingleton(new DapperContext(connectionString));
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
