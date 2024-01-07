using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WhoIsMyGranddaddy.Data.Database;
using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly IAppDbContext _context;
    private const int PageSize = 8;
    
    public PersonRepository(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Person?> GetPersonAsync(string identityNumber)
    {
        return await _context.Persons.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
    }
    
    public async Task<List<Person>> GetRootAscendantsByIdentityNumberAsync(string identityNumber)
    {
        var identityNumberParam = new SqlParameter("@IdentityNumber", identityNumber);
        
        const string query = "EXEC [site].[GetRootAscendantsByIdentityNumber] @IdentityNumber";

        var dataResult = await _context.ExecuteStoredProcedure<Person>(query, identityNumberParam);

        return dataResult.Item1;
    }

    public async Task<Tuple<List<PersonWithPartner>, int>> GetDescendantsByIdentityNumberAsync(string? identityNumber, int pageNumber = 1)
    {
        var identityNumberParam = new SqlParameter("@IdentityNumber", identityNumber ?? (object)DBNull.Value);
        var pageSizeParam = new SqlParameter("@PageSize", PageSize);
        var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
        var maxPagesParam = new SqlParameter("@MaxPages", SqlDbType.Int) { Direction = ParameterDirection.Output };

        const string query = "EXEC [site].[GetDescendantsByIdentityNumber] @IdentityNumber, @PageSize, @PageNumber, @MaxPages OUTPUT";

        var (people, maxPages) = await  _context.ExecuteStoredProcedure<PersonWithPartner>(
            query,
            identityNumberParam,
            pageSizeParam,
            pageNumberParam,
            maxPagesParam
        );

        return Tuple.Create(people, maxPages);
    }


}