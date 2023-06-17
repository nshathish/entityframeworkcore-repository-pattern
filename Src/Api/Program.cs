using Data;

string GetConnectionString()
{
    var baseDir = AppDomain.CurrentDomain.BaseDirectory;
    baseDir = baseDir.Remove(baseDir.IndexOf("Src", StringComparison.Ordinal));
    var dbPath = Path.Combine(baseDir, "DB\\my_app.db");
    var connectionString = $"Data Source={dbPath}";
    return connectionString;
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(configure => configure.AddConsole());
builder.Services.AddDataLayer(GetConnectionString());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();