using Microsoft.AspNetCore.Mvc;
using WhoIsMyGranddaddy.Domain.Models;
using WhoIsMyGranddaddy.Domain.Services;
using WhoIsMyGranddaddy.Server.Models;

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

    [HttpGet]
    public async Task<IActionResult> GetFamilyTree()
    {
        var familyTree = await _familyTreeService.GetFamilyTreeAsync();
        
        return Ok(new GenericResponseModel<List<FamilyMemberModel>>(true, "Family Tree successfully retrieved", familyTree));
    }

    [HttpGet("GetRootAscendants")]
    public async Task<IActionResult> GetRootAscendants(string identityNumber)
    {
        try
        {
            var rootAscendants = await _familyTreeService.GetRootAscendants(identityNumber);

            return Ok(new GenericResponseModel<List<FamilyMemberModel>>(true, "Root Ascendants successfully retrieved",
                rootAscendants));
        }
        catch (InvalidOperationException oe)
        {
            return BadRequest(new GenericResponseModel<List<FamilyMemberModel>>(false, oe.Message, new List<FamilyMemberModel>()));
        }
    }
    
    [HttpGet("GetDescendants")]
    public async Task<IActionResult> GetDescendants(string? identityNumber, int? pageNumber)
    {
        try
        {
            var (descendants, maxPages) = await _familyTreeService.GetDescendants(identityNumber);

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
        catch (InvalidOperationException oe)
        {
            return BadRequest(new GenericResponseModel<List<FamilyMemberModel>>(false, oe.Message, new List<FamilyMemberModel>()));
        }
    }
}