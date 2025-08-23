using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OneBus.Application.Interfaces.Services;
using OneBus.Application.Services;
using OneBus.Infra.Data.Repositories;

namespace OneBus.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Scan(c => c.FromAssemblyOf<UserRepository>().AddClasses());
            services.Scan(c => c.FromAssemblyOf<UserService>().AddClasses());
            services.AddValidatorsFromAssembly(typeof(IBaseReadOnlyService<,,>).Assembly);
            return services;
        }
    }
}
