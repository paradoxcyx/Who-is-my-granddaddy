using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Data.Database;

public interface IAppDbContext
{
    /// <summary>
    /// Persons DbSet
    /// </summary>
    public DbSet<Person> Persons { get; set; }
    
    /// <summary>
    /// Custom Persons DbSet used for retrieving descendants
    /// </summary>
    public DbSet<PersonWithPartner> PersonsWithPartner { get; set; }
    
    /// <summary>
    /// Function to execute a stored procedure and return results
    /// </summary>
    /// <param name="query">Custom query text</param>
    /// <param name="parameters">Sql parameters</param>
    /// <typeparam name="T">Type of return object</typeparam>
    /// <returns></returns>
    public Task<Tuple<List<T>, int>> ExecuteStoredProcedure<T>(string query, params SqlParameter[] parameters) where T : class;
}