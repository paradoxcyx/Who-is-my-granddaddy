using AutoMapper;
using WhoIsMyGranddaddy.Data.Repositories;
using WhoIsMyGranddaddy.Domain.Models;

namespace WhoIsMyGranddaddy.Domain.Services;

public class FamilyTreeService : IFamilyTreeService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    
    public FamilyTreeService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    

    public async Task<Tuple<List<FamilyMemberModel>, int>> GetDescendants(string? identityNumber = null, int pageNumber = 1)
    {
        //Only verify the person if identity number filtering is applied
        if (!string.IsNullOrEmpty(identityNumber))
        {
            var person = await _personRepository.GetPersonAsync(identityNumber);

            if (person == null)
                throw new InvalidOperationException("This person does not exist!");
        }
        
        var (people, maxPages) = await _personRepository.GetDescendantsByIdentityNumberAsync(identityNumber, pageNumber);

        var descendants = _mapper.Map<List<FamilyMemberModel>>(people);

        return Tuple.Create(descendants, maxPages);
    }
    
    public async Task<List<FamilyMemberModel>> GetRootAscendants(string identityNumber)
    {
        var person = await _personRepository.GetPersonAsync(identityNumber);

        if (person == null)
            throw new InvalidOperationException("This person does not exist!");
        
        var people = await _personRepository.GetRootAscendantsByIdentityNumberAsync(identityNumber);

        var ascendants = _mapper.Map<List<FamilyMemberModel>>(people);

        return ascendants;
    }
    
}