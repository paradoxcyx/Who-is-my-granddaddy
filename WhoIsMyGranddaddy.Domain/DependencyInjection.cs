using Microsoft.Extensions.DependencyInjection;
using WhoIsMyGranddaddy.Domain.Services;

namespace WhoIsMyGranddaddy.Domain;

public static class DependencyInjection
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IFamilyTreeService, FamilyTreeService>();
    }
}