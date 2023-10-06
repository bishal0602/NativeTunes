using NativeTunes.API.Services;
using NativeTunes.Application.Contracts.Services;

namespace NativeTunes.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddAutoMapper(typeof(DependencyInjection));
            return services;
        }
    }
}
