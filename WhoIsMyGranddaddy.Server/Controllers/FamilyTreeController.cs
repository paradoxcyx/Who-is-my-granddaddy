﻿using Microsoft.AspNetCore.Mvc;
using WhoIsMyGranddaddy.Domain.Models;
using WhoIsMyGranddaddy.Domain.Services;
using WhoIsMyGranddaddy.Server.Shared.Models;

namespace WhoIsMyGranddaddy.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class FamilyTreeController : ControllerBase
{
    private readonly IFamilyTreeService _familyTreeService;
    
    public FamilyTreeController(IFamilyTreeService familyTreeService)
    {
        _familyTreeService = familyTreeService;
    }

    [HttpGet("GetRootAscendants")]
    public async Task<IActionResult> GetRootAscendants(string identityNumber)
    {
        var rootAscendants = await _familyTreeService.GetRootAscendants(identityNumber);

        return Ok(new GenericResponseModel<List<FamilyMemberModel>>(true, "Root Ascendants successfully retrieved",
            rootAscendants));
    }
    
    [HttpGet("GetDescendants")]
    public async Task<IActionResult> GetDescendants(string? identityNumber, int pageNumber)
    {
        var (descendants, maxPages) = await _familyTreeService.GetDescendants(identityNumber, pageNumber);
        
        var response = new GenericResponseModel<List<FamilyMemberModel>>
        {
            Success = true,
            Message = "Descendants successfully retrieved",
            Data = descendants,
            Page = pageNumber,
            MaxPages = maxPages
        };
        
        return Ok(response);
    }
}