﻿using WhoIsMyGranddaddy.Domain.Models;

namespace WhoIsMyGranddaddy.Domain.Services;

public interface IPersonService
{
    /// <summary>
    /// Retrieving full family tree
    /// </summary>
    /// <returns>List of full family tree</returns>
    Task<List<PersonModel>> GetFullFamilyTree();
    
    /// <summary>
    /// Retrieving all family descendants for specified Identity Number
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <returns>List of family descendants</returns>
    Task<List<PersonModel>> GetFamilyTreeDescendants(string identityNumber);

    /// <summary>
    /// Retrieving root ascendants for specified Identity Number
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <returns>Root ascendants (Mother & Father)</returns>
    Task<List<PersonModel>> GetRootAscendants(string identityNumber);

}