using System.Reflection;
using IndigyBackendTestAPI.Domain.Interfaces.Repositories;
using IndigyBackendTestAPI.Application.Commands.Employee.Handler;
using IndigyBackendTestAPI.Infrastructure.Repositories;
using MediatR;
using IndigyBackendTestAPI.Application.Mapping;
using IndigyBackendTestAPI.Application.Commands.Employee;
using IndigyBackendTestAPI.Application.Queries.Employee.Handler;
using IndigyBackendTestAPI.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using IndigyBackendTestAPI.Application.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(
    typeof(MappingProfile).Assembly,
    Assembly.GetExecutingAssembly()
);
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateEmployee>();
    });

builder.Services.AddMediatR(
    typeof(CreateEmployeeHandler).Assembly,
    typeof(DeleteEmployeeHandler).Assembly,
    typeof(UpdateEmployeeHandler).Assembly,
    typeof(GetAllEmployeesHandler).Assembly,
    typeof(GetEmployeeByIdHandler).Assembly
);
builder.Services.AddScoped<IEmployeeRepositories, EmployeeRepositories>();

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
