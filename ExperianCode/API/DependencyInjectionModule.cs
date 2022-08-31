using Microsoft.Extensions.DependencyInjection;

namespace ExperianCode.API
{
    public static class DependencyInjectionModule
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddScoped<IPhotos, Photos>();
            services.AddScoped<IAlbums, Albums>();
            return services;
               
        }
    }
}
