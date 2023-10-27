
using Domain.Factories.Categorias;
using Domain.Factories.Cuentas;
using Domain.Factories.Movimientos;
using Domain.Factories.Usuarios;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IUsuarioFactory, UsuarioFactory>();
            services.AddScoped<ICategoriaFactory, CategoriaFactory>();
            services.AddScoped<ICuentaFactory, CuentaFactory>();
            services.AddScoped<IMovimientoFactory, MovimientoFactory>();


            return services;

        }
    }
}
