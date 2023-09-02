using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using Services.Services.Contracts;

namespace Services
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();

            return services;
        }
    }
}
