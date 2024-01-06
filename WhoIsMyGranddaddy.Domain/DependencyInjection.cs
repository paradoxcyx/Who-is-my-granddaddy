using Microsoft.Extensions.DependencyInjection;
using WhoIsMyGranddaddy.Domain.Services;

namespace WhoIsMyGranddaddy.Domain;

public static class DependencyInjection
{
    /// <summary>
    /// Injecting Domain related services and adding the automapper service
    /// </summary>
    /// <param name="services"></param>
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IFamilyTreeService, FamilyTreeService>();
        
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
    }
}