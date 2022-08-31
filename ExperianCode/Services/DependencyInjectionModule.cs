using Microsoft.Extensions.DependencyInjection;

namespace ExperianCode.Services
{
    public static class DependencyInjectionModule
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IPhotoAlbumService, PhotoAlbumService>();
            return services;
        }
    }
}
