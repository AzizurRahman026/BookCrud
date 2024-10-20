using Service;
using ServiceContracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IBookCountService, BookService>();

var app = builder.Build();

app.MapControllers();

app.Run();