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
    
    public async Task<List<FamilyMemberModel>> GetFamilyTreeAsync()
    {
        var people = (await _personRepository.GetPersonsAsync()).OrderBy(x => x.MotherId).ThenBy(x => x.FatherId).ToList();
        
        return BuildFamilyTree(people);
    }

    private static List<FamilyMemberModel> BuildFamilyTree(IReadOnlyList<Person> people, bool isFiltered = false, string? identityNumber = null)
    {
        if (isFiltered && !string.IsNullOrEmpty(identityNumber))
        {
            var root = people.FirstOrDefault(x => x.IdentityNumber.Equals(identityNumber));

            if (root != null)
            {
                root.FatherId = null;
                root.MotherId = null;
            }
        }
        
        var familyMembers = people.Select(person => new FamilyMemberModel
        {
            Id = person.Id,
            BirthDate = person.BirthDate,
            IdentityNumber = person.IdentityNumber,
            Fid = person.FatherId,
            Mid = person.MotherId,
            Name = person.Name,
            Surname = person.Surname
        }).ToList();

        var familyMembersSet = new HashSet<FamilyMemberModel>(familyMembers);

        foreach (var person in people)
        {
            if (person is not { FatherId: not null, MotherId: not null }) continue;
            
            var father = familyMembersSet.FirstOrDefault(y => y.Id == person.FatherId && y.Id != person.Id);
            var mother = familyMembersSet.FirstOrDefault(y => y.Id == person.MotherId && y.Id != person.Id);

            if (father == null || mother == null) continue;
            
            if (father.Pids == null || father.Pids.Length < 1)
            {
                father.Pids = new[] { mother.Id };
            }

            if (mother.Pids == null || mother.Pids.Length < 1)
            {
                mother.Pids = new[] { father.Id };
            }
        }

        return familyMembers;
    }
    
    public async Task<List<FamilyMemberModel>> GetDescendants(string? identityNumber = null)
    {
        var isFiltered = false;
        
        //Only verify the person if identity number filtering is applied
        if (!string.IsNullOrEmpty(identityNumber))
        {
            var person = await _personRepository.GetPersonAsync(identityNumber);

            if (person == null)
                throw new InvalidOperationException("This person does not exist!");
        }

        isFiltered = !string.IsNullOrEmpty(identityNumber);
        
        var people = await _personRepository.GetDescendantsByIdentityNumberAsync(identityNumber);
        
        return BuildFamilyTree(people, isFiltered, identityNumber);
    }
    
    public async Task<List<FamilyMemberModel>> GetRootAscendants(string identityNumber)
    {
        var person = await _personRepository.GetPersonAsync(identityNumber);

        if (person == null)
            throw new InvalidOperationException("This person does not exist!");
        
        var people = await _personRepository.GetRootAscendantsByIdentityNumberAsync(identityNumber);

        return BuildFamilyTree(people);
    }
    
}