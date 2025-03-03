using Desafio.AuthService.Helpers;
using Desafio.AuthService.Migrations;
using Desafio.AuthService.Models;
using Desafio.AuthService.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataContexts(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddTransient<IEmailSender<User>, EmailSender>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();