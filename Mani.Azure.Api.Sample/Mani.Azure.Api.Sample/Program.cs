using Mani.Azure.Api.Data.Interfaces.DataAccess;
using Mani.Azure.Api.Data.Interfaces;
using Mani.Azure.Api.Business.Interfaces;
using Mani.Azure.Api.Business;
using Jerry.Data.DataAccess;
using Mani.Azure.Api.Data.DataAccess;
using Mani.Azure.Api.Data;
using Mani.Azure.Api.Common.Validators;
using Mani.Azure.Api.Common;
using Mani.Azure.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeBusinessLayer, EmployeeBusinessLayer>();
builder.Services.AddScoped<IEmployeeDataLayer, EmployeeDataLayer>();
builder.Services.AddScoped<ISqlConnectionProvider, EmployeeDBConnection>();
builder.Services.AddScoped<ISqlDapperDataAccess, SqlDapperDataAccess>();
builder.Services.AddScoped<IEmployeeValidator, EmployeeValidator>();
builder.Services.Configure<AppConfig>(builder.Configuration.GetSection(nameof(AppConfig)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
