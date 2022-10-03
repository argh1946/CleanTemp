using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using React.Mapper;

namespace React.IoC
{
    public static class ServiceModuleExtentions
    {
        public static void RegisterApiServices(this IServiceCollection serviceCollection)
        {
            var automapper = RegisterAutoMapperService();
            serviceCollection.AddSingleton(automapper);
        }

        private static IMapper RegisterAutoMapperService()
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
