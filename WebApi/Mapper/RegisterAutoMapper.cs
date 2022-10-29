using AutoMapper;
using Core.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using React.Mapper;

namespace WebApi.Mapper
{
    public static class RegisterAutoMapper
    {
        public static void RegisterAutoMapperService(this IServiceCollection serviceCollection)
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
