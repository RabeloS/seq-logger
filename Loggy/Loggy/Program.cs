using Loggy.ServicesCollections;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.AddControllers();
    builder.Services.AddTransient<ExceptionHandlerError>();

    var app = builder.Build();
    app.UseSerilogRequestLogging();

    Log.Information("Starting up");
    


    // Configure the HTTP request pipeline.

    app.UseAuthorization();
    app.MapControllers();
    app.MapGet("/", () => "Loggy Service!");
    app.UseMiddleware<ExceptionHandlerError>();

    app.Run();

}
catch (Exception)
{

    throw;
}
finally
{
    Log.CloseAndFlush();
    Log.Information("Shut down complete");
}




// Add services to the container.


