using BookCrudTest;
using Serilog;
using Service;
using ServiceContracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IBookCountService, BookService>();

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Logs to console
    // .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // Logs to a file
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();



// Add custom middleware
app.UseMiddleware<NameFormattingMiddleware>();

app.MapControllers();

app.Run();