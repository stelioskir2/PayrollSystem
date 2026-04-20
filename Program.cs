using Microsoft.EntityFrameworkCore;
using PayrollSystem.Services.Interfaces;
using PayrollSystem.Services.Implementations;
using PayrollSystem.Data;
using PayrollSystem.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "Payroll API", 
        Version = "v1" 
    });
});

builder.Services.AddDbContext<PayrollContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDB")));

builder.Services.AddControllers();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();