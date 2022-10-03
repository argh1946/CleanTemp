using Microsoft.Extensions.DependencyInjection;
using Core.Contracts;
using Infrastructure.Data;
using System.Linq;
using Core.Contracts.AtmCrs;


namespace Infrastructure.IoC
{
    public static class ServiceModuleExtentions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IAtmCrsRepository, AtmCrsRepository>();           
                 
        }
    }
}