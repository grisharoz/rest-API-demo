using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Контейнер работает только по HTTP (5004)

builder.WebHost.ConfigureKestrel(serverOptions => {
    serverOptions.ListenAnyIP(5004); // HTTP всегда

    // HTTPS только если сертификаты существуют (Docker/prod)
    var certPath = "/https/origin.crt";
    var keyPath = "/https/origin.key";
    
    if (File.Exists(certPath) && File.Exists(keyPath))
    {
        serverOptions.ListenAnyIP(443, listenOptions => {
            var cert = X509Certificate2.CreateFromPemFile(certPath, keyPath);
            listenOptions.UseHttps(cert);
        });
    }
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<UsersContext>(opt =>
    opt.UseInMemoryDatabase("UsersList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
            "http://localhost:3000",
            "https://localhost:3000",
            "https://roulette-simulator-iojb.vercel.app",
            "https://valuebargains.store"
        );
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
