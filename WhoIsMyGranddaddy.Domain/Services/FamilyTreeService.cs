using WhoIsMyGranddaddy.Data.Entities;
using WhoIsMyGranddaddy.Data.Repositories;
using WhoIsMyGranddaddy.Domain.Models;

namespace WhoIsMyGranddaddy.Domain.Services;

public class FamilyTreeService : IFamilyTreeService
{
    private readonly IPersonRepository _personRepository;

    public FamilyTreeService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task<List<PersonModel>> GetFamilyTree()
    {
        var people = await _personRepository.GetPersonsAsync();
        var peopleDictionary = people.ToDictionary(p => p.Id);
        
        var familyTree = BuildFamilyTree(peopleDictionary);
        return familyTree;
    }
    public async Task<List<PersonModel>> GetDescendants(string identityNumber)
    {
        var person = await _personRepository.GetPersonAsync(identityNumber);

        if (person == null)
            throw new InvalidOperationException("This person does not exist!");
        
        var people = await _personRepository.GetDescendantsByIdentityNumberAsync(identityNumber);
        var peopleDictionary = people.ToDictionary(p => p.Id);
        
        // Organize people into a hierarchy
        var familyTree = BuildFamilyTree(peopleDictionary, person.Id);
        return familyTree;
    }
    
    public async Task<List<PersonModel>> GetRootAscendants(string identityNumber)
    {
        var person = await _personRepository.GetPersonAsync(identityNumber);

        if (person == null)
            throw new InvalidOperationException("This person does not exist!");
        
        var people = await _personRepository.GetRootAscendantsByIdentityNumberAsync(identityNumber);
        
        return people.Select(x => new PersonModel
        {
            IdentityNumber = x.IdentityNumber,
            Name = x.Name,
            Surname = x.Surname,
            BirthDate = x.BirthDate
        }).ToList();
    }
    private List<PersonModel> BuildFamilyTree(Dictionary<int, Person> people, int? parentId = null)
    {
        var children = people.Values
            .Where(p => (parentId.HasValue ? p.FatherId == parentId : p.FatherId == null) || p.MotherId == parentId)
            .OrderBy(p => p.BirthDate).ToList();
        
        return children.Select(child => new PersonModel
            {
                IdentityNumber = child.IdentityNumber,
                Name = child.Name,
                Surname = child.Surname,
                BirthDate = child.BirthDate,
                Children = BuildFamilyTree(people, child.Id)
            })
            .ToList();
    }
}