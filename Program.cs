using BRQ.Interfaces;
using BRQ.Rules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ITradeCategoryRule, LowRiskRule>();
builder.Services.AddTransient<ITradeCategoryRule, MediumRiskRule>();
builder.Services.AddTransient<ITradeCategoryRule, HighRiskRule>();
builder.Services.AddTransient<TradeCategoryClassifier>();

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
