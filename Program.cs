// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using NotesApplication.Data;
using NotesApplication.Repositories.Implementations;
using NotesApplication.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext and Repository in the DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=NotesApplication.db"));

builder.Services.AddScoped<INoteRepository, NoteRepository>(); // Register INoteRepository

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();
var logger = app.Logger;

logger.LogInformation("Hello, World! Logging is configured.");
logger.LogWarning("This is a warning message.");
logger.LogError("This is an error message.");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
