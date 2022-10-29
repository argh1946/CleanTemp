using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using NLog;
using NLog.Web;
using FluentValidation.AspNetCore;
using WebApi.Middleware;
using Core.Contracts;
using System.Reflection;
using WebApi.Mapper;

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
    builder.Services.AddControllers().AddFluentValidation().ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = CustomProblemDetails.MakeValidationResponse;
    }); 

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //------------------------------- IOC ------------------------------------
    builder.Services.Scan(current => current
               //Register Core Service
               .FromAssemblies(typeof(Core.UseCases.AtmCrsService).GetTypeInfo().Assembly)
               .AddClasses(theClass => theClass.InExactNamespaceOf<Core.UseCases.AtmCrsService>())
               .AsSelf()
               .AsImplementedInterfaces()
               .WithScopedLifetime()
               //Register Infrastructure Service
               .FromAssemblies(typeof(Infrastructure.Data.Repositories.AtmCrsRepository).GetTypeInfo().Assembly)
               .AddClasses(theClass => theClass.InExactNamespaceOf<Infrastructure.Data.Repositories.AtmCrsRepository>())
               .AsSelf()
               .AsImplementedInterfaces()
               .WithScopedLifetime()
               //Register Api Services
               .FromAssemblies(typeof(Validation.AtmCrsValidator).GetTypeInfo().Assembly)
               .AddClasses(theClass => theClass.InExactNamespaceOf<Validation.AtmCrsValidator>())
               .AsSelf()
               .AsImplementedInterfaces()
               .WithScopedLifetime()
               );

    builder.Services.RegisterAutoMapperService();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    //builder.Services.AddScoped<IUnitOfWorkDeposit, UnitOfWorkDeposit>();
    //--------------------------------------------------------------------------

   
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

    app.UseMiddleware<ExceptionMiddleware>();
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