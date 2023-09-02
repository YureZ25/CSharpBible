using Data.Repos;
using Data.Repos.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepo, PersonRepo>();

            return services;
        }
    }
}
