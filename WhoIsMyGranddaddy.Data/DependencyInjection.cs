using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhoIsMyGranddaddy.Data.Database;
using WhoIsMyGranddaddy.Data.Repositories;

namespace WhoIsMyGranddaddy.Data;

public static class DependencyInjection
{
    /// <summary>
    /// Injecting database related repositories and adding the Db Context
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString"></param>
    public static void AddData(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IPersonRepository, PersonRepository>();
        
    }
}