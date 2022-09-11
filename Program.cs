using ApmErrorTransaction;
using Elastic.Apm.NetCoreAll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddSingleton<TransactionTest>();

var app = builder.Build();

app.UseAllElasticApm(builder.Configuration);
app.UseHttpLogging();
// Configure the HTTP request pipeline.


app.MapGet("/helou", () => new
{
    Helou = "jasld"
});

//app.MapGet("/error", async () => await new TransactionFactory().CreateTransaction());

try
{
    await new TransactionFactory().CreateTransaction(app.Services.GetService<TransactionTest>());
}
catch
{

}


app.Run();
