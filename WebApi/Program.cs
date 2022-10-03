using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.IoC;
using Infrastructure.IoC;
using React.IoC;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
    });

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddCors();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.RegisterCoreServices();
    builder.Services.RegisterInfrastructureServices();
    builder.Services.RegisterApiServices();

    var app = builder.Build();

    app.UseCors(p =>
    {
        p.AllowAnyOrigin();
        p.AllowAnyMethod();
        p.AllowAnyHeader();
    });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}