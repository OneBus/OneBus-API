using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OneBus.Application.Interfaces.Services;
using OneBus.Application.Services;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.Repositories;
using System.Reflection;

namespace OneBus.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {            
            services.AddGenericRepositories(typeof(BaseReadOnlyRepository<,>).Assembly);
           
            services.AddValidatorsFromAssembly(typeof(IBaseReadOnlyService<,,>).Assembly);

            services.AddGenericServices(typeof(IBaseReadOnlyService<,,>).Assembly);

            return services;
        }

        private static IServiceCollection AddGenericRepositories(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false }) // Apenas classes concretas
                .ToList();

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                                (i.GetGenericTypeDefinition() == typeof(IBaseReadOnlyRepository<,>) ||
                                 i.GetGenericTypeDefinition() == typeof(IBaseRepository<,>)))
                    .ToList();

                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, type);
                }
            }

            return services;
        }
        
        private static IServiceCollection AddGenericServices(this IServiceCollection services, Assembly assembly)
        {
            services.AddScoped<ITokenService, TokenService>();

            var types = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false }) // Apenas classes concretas
                .ToList();

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                                (i.GetGenericTypeDefinition() == typeof(IBaseReadOnlyService<,,>) ||
                                 i.GetGenericTypeDefinition() == typeof(IBaseService<,,,,>)))
                    .ToList();

                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, type);
                }
            }

            return services;
        }        
    }
}
