using MongoDBWrapper.Configuration;
using Watoocook.Domain;
using Watoocook.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRepositories();
builder.Services.AddMongodbWrapperConfiguration();
builder.Services.AddUseCases();
builder.Services.AddSwaggerGen();
//builder.Configuration.AddEnvironmentVariables().AddJsonFile("mongodb_apsettings.json");

var app = builder.Build();
ServiceActivator.Configure(app.Services);

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
