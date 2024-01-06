using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WhoIsMyGranddaddy.Data.Database;
using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;
    private const int PageSize = 8;
    
    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Person?> GetPersonAsync(string identityNumber)
    {
        return await _context.Persons.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
    }
    
    public Task<List<Person>> GetRootAscendantsByIdentityNumberAsync(string identityNumber)
    {
        var identityNumberParam = new SqlParameter("@IdentityNumber", identityNumber);
        
        return _context.Persons.FromSqlInterpolated($"EXEC [site].[GetRootAscendantsByIdentityNumber] {identityNumberParam}").ToListAsync();
    }

    public async Task<Tuple<List<PersonWithPartner>, int>> GetDescendantsByIdentityNumberAsync(string? identityNumber, int pageNumber = 1)
    {
        var identityNumberParam = new SqlParameter("@IdentityNumber", identityNumber ?? (object)DBNull.Value);
        var pageSizeParam = new SqlParameter("@PageSize", PageSize);
        var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
        var maxPagesParam = new SqlParameter("@MaxPages", SqlDbType.Int) { Direction = ParameterDirection.Output };

        const string query = "EXEC [site].[GetDescendantsByIdentityNumber] @IdentityNumber, @PageSize, @PageNumber, @MaxPages OUTPUT";

        var people = await _context.PersonsWithPartner
            .FromSqlInterpolated(FormattableStringFactory.Create(query, identityNumberParam, pageSizeParam, pageNumberParam, maxPagesParam))
            .ToListAsync();

        // Retrieve the value of the output parameter
        var maxPages = (int)maxPagesParam.Value;

        return Tuple.Create(people, maxPages);
    }


}