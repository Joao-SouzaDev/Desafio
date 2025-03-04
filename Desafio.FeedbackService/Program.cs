using Desafio.FeedbackService.Helpers;
using Desafio.FeedbackService.Migrations;
using Desafio.FeedbackService.Services;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Permitir chamadas do React
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDataContexts(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddSingleton<MqServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(corsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
