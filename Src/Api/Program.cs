using Data;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(configure => configure.AddConsole());

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var baseDir = AppDomain.CurrentDomain.BaseDirectory;
    baseDir = baseDir.Remove(baseDir.IndexOf("Src", StringComparison.Ordinal));
    var dbPath = Path.Combine(baseDir, "DB\\my_app.db");
    var connectionString = $"Data Source={dbPath}";
    options.UseSqlite(connectionString);
});
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();