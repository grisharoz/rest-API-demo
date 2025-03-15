using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to use self-signed certificate
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5004);  // HTTP
    serverOptions.ListenAnyIP(7024, listenOptions =>
    {
        // Use a self-signed certificate or load from environment
        listenOptions.UseHttps();  // This will use the certificate specified in environment variables
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<UsersContext>(opt =>
    opt.UseInMemoryDatabase("UsersList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.WithOrigins("http://localhost:3000", "https://roulette-simulator-iojb.vercel.app");
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

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
