using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhoIsMyGranddaddy.Data.Database;
using WhoIsMyGranddaddy.Data.Repositories;

namespace WhoIsMyGranddaddy.Data;

public static class DependencyInjection
{
    public static void AddData(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IPersonRepository, PersonRepository>();
        
    }
}