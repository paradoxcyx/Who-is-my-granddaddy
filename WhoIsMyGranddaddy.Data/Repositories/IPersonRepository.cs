using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Data.Repositories;

public interface IPersonRepository
{
    /// <summary>
    /// Retrieving the specific person from the database
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <returns>The person</returns>
    public Task<Person?> GetPersonAsync(string identityNumber);
    
    /// <summary>
    /// Getting the root ascendants for a specific ID Number. IE. Mother & father
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <returns>The root ascendants for the person</returns>
    public Task<List<Person>> GetRootAscendantsByIdentityNumberAsync(string identityNumber);
    
    /// <summary>
    /// Get the descendants for a specific ID Number
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <param name="pageNumber">The page number</param>
    /// <returns>All descendents for an identity number if specified</returns>
    public Task<Tuple<List<PersonWithPartner>, int>> GetDescendantsByIdentityNumberAsync(string? identityNumber, int pageNumber = 1);
}