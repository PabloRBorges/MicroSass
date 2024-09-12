using MicroSass.Application;
using MicroSass.Domain.Entities;
using MicroSass.Domain.Interfaces;
using MicroSass.Infrastructure.Data;
using MicroSass.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados (usando SQL Server como exemplo)
var sqlconnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

// Registrar reposit�rios no cont�iner de inje��o de depend�ncia
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Subscription>, SubscriptionRepository>();

// Registrar servi�os de aplica��o no cont�iner de inje��o de depend�ncia
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SubscriptionService>();

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
