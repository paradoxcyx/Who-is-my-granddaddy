using WhoIsMyGranddaddy.Domain.Models;

namespace WhoIsMyGranddaddy.Domain.Services;

public interface IFamilyTreeService
{
    /// <summary>
    /// Retrieving all family descendants for specified Identity Number
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <param name="pageNumber">The page number></param>
    /// <returns>List of family descendants</returns>
    Task<Tuple<List<FamilyMemberModel>, int>> GetDescendants(string? identityNumber, int pageNumber = 1);

    /// <summary>
    /// Retrieving root ascendants for specified Identity Number
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <returns>Root ascendants (Mother & Father)</returns>
    Task<List<FamilyMemberModel>> GetRootAscendants(string identityNumber);

}