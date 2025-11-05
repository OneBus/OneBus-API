using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OneBus.Application.Interfaces.Services;
using OneBus.Application.Services;
using OneBus.Application.Workers;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Infra.Data.Repositories;
using System.Globalization;

namespace OneBus.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
            services.AddValidatorsFromAssembly(typeof(IBaseReadOnlyService<,,>).Assembly);

            services.Scan(scan => scan
            .FromAssemblies(typeof(BaseReadOnlyRepository<,>).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseReadOnlyRepository<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.Scan(scan => scan
            .FromAssemblies(typeof(IBaseReadOnlyService<,,>).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IBaseReadOnlyService<,,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.AddHostedService<VehicleOperationWorker>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IDashboardService, DashboardService>();
            return services;
        }
    }
}
