using WhoIsMyGranddaddy.Data.Entities;
using WhoIsMyGranddaddy.Data.Repositories;
using WhoIsMyGranddaddy.Domain.Models;

namespace WhoIsMyGranddaddy.Domain.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task<List<PersonModel>> GetFullFamilyTree()
    {
        var people = await _personRepository.GetPersonsAsync();

        var familyTree = BuildFamilyTree(people);
        return familyTree;
    }
    public async Task<List<PersonModel>> GetFamilyTreeDescendants(string identityNumber)
    {
        var person = await _personRepository.GetPersonAsync(identityNumber);

        if (person == null)
            throw new InvalidOperationException("This person does not exist!");
        
        var people = await _personRepository.GetDescendantsByIdentityNumberAsync(identityNumber);

        // Organize people into a hierarchy
        var familyTree = BuildFamilyTree(people, person.Id);
        return familyTree;
    }
    
    public async Task<List<PersonModel>> GetRootAscendants(string identityNumber)
    {
        var people = await _personRepository.GetRootAscendantsByIdentityNumberAsync(identityNumber);

        return people.Select(x => new PersonModel
        {
            MotherId = x.MotherId,
            FatherId = x.FatherId,
            IdentityNumber = x.IdentityNumber,
            Name = x.Name,
            Surname = x.Surname,
            BirthDate = x.BirthDate
        }).ToList();
    }
    private List<PersonModel> BuildFamilyTree(IEnumerable<Person> people, int? parentId = null)
    {
        var children = people
            .Where(p => (parentId.HasValue ? p.FatherId == parentId : p.FatherId == null) || p.MotherId == parentId).ToList();
        
        return children.Select(child => new PersonModel
            {
                MotherId = child.MotherId,
                FatherId = child.FatherId,
                IdentityNumber = child.IdentityNumber,
                Name = child.Name,
                Surname = child.Surname,
                BirthDate = child.BirthDate,
                Children = BuildFamilyTree(people, child.Id)
            })
            .OrderBy(x => x.BirthDate)
            .ToList();
    }
}