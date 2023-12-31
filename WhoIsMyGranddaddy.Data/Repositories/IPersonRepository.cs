using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Data.Repositories;

public interface IPersonRepository
{
    /// <summary>
    /// Retrieving all people in family tree
    /// </summary>
    /// <returns></returns>
    public Task<List<Person>> GetPersonsAsync();
    
    /// <summary>
    /// Getting the root ascendants for a specific ID Number. IE. Mother & father
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <returns></returns>
    public Task<List<Person>> GetRootAscendantsByIdentityNumberAsync(string identityNumber);
    
    /// <summary>
    /// Get the descendants for a specific ID Number
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <returns></returns>
    public Task<List<Person>> GetDescendantsByIdentityNumberAsync(string identityNumber);
}