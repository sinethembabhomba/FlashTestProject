using Microsoft.Extensions.DependencyInjection;
using Sensitivewords_Business.Contracts;
using Sensitivewords_Business.Services;
using Sensitivewords_Repository.Data.Repo;

namespace Sensitivewords_API.API_Services_Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISensitiveWordsService, SensitiveWordsServices>();
            services.AddScoped<ISensitiveWordsRepository, SensitiveWordsRepository>();
        
            return services;

        }
    }
}
