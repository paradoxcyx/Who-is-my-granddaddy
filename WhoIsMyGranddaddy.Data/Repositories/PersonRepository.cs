using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using WhoIsMyGranddaddy.Data.Database;
using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;
    
    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Person?> GetPersonAsync(string identityNumber)
    {
        return await _context.Persons.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
    }
    public async Task<List<Person>> GetPersonsAsync()
    {
        var dbPersons = await _context.Persons.OrderBy(x => x.BirthDate).ToListAsync();
        return dbPersons;
    }

    public Task<List<Person>> GetRootAscendantsByIdentityNumberAsync(string identityNumber)
    {
        var rootAscendantsQuery = _context.GetRootAscendantsByIdentityNumber(identityNumber);
        return rootAscendantsQuery.ToListAsync();
    }

    public async Task<Tuple<List<Person>, int>> GetDescendantsByIdentityNumberAsync(string? identityNumber, int pageNumber = 1)
    {
        var identityNumberParam = new SqlParameter("@IdentityNumber", identityNumber ?? (object)DBNull.Value);
        var pageSizeParam = new SqlParameter("@PageSize", 8);
        var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
        var maxPagesParam = new SqlParameter("@MaxPages", SqlDbType.Int) { Direction = ParameterDirection.Output };

        var people = await _context.Persons.FromSqlRaw(
            "EXEC [site].[GetDescendantsByIdentityNumber] @IdentityNumber, @PageSize, @PageNumber, @MaxPages OUTPUT",
            identityNumberParam, pageSizeParam, pageNumberParam, maxPagesParam).ToListAsync();

        // Retrieve the value of the output parameter
        var maxPages = (int)maxPagesParam.Value;

        return Tuple.Create(people, maxPages);
    }
}