using Microsoft.EntityFrameworkCore;
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

    public Task<List<Person>> GetDescendantsByIdentityNumberAsync(string? identityNumber)
    {
        var descendantsQuery = _context.GetDescendantsByIdentityNumber(identityNumber);
        return descendantsQuery.ToListAsync();
    }
}