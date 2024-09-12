using MicroSass.Application;
using MicroSass.Domain.Entities;
using MicroSass.Domain.Interfaces;
using MicroSass.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registrar repositórios no contêiner de injeção de dependência
builder.Services.AddSingleton<IRepository<User>, UserRepository>();
builder.Services.AddSingleton<IRepository<Subscription>, SubscriptionRepository>();

// Registrar serviços de aplicação no contêiner de injeção de dependência
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
