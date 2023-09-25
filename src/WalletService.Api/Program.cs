using WalletService.Api;
using WalletService.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.AddApplication();
builder.AddInfrastructure();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapWalletEndpoints();
app.MapHealthChecks("/ok");

await app.RunAsync();