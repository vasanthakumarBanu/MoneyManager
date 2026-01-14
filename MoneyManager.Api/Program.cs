using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Domain.Interfaces;
using MoneyManager.Infrastructure;
using MoneyManager.Application.UseCases;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<AddTransactionUseCase>();
builder.Services.AddScoped<GetAllTransactionsUseCase>();
builder.Services.AddScoped<GetTransactionByIdUseCase>();
builder.Services.AddScoped<UpdateTransactionUseCase>();
builder.Services.AddScoped<DeleteTransactionUseCase>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
