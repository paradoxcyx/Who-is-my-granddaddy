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
        var familyTree = (await _familyTreeService.GetFamilyTree()).Take(1).ToList();
        
        return Ok(new GenericResponseModel<List<PersonModel>>(true, "Family Tree successfully retrieved", familyTree));
    }

    [HttpGet("GetRootAscendants")]
    public async Task<IActionResult> GetRootAscendants(string identityNumber)
    {
        try
        {
            var rootAscendants = await _familyTreeService.GetRootAscendants(identityNumber);

            return Ok(new GenericResponseModel<List<PersonModel>>(true, "Root Ascendants successfully retrieved",
                rootAscendants));
        }
        catch (InvalidOperationException oe)
        {
            return BadRequest(new GenericResponseModel<List<PersonModel>>(false, oe.Message, new List<PersonModel>()));
        }
    }
    
    [HttpGet("GetDescendants")]
    public async Task<IActionResult> GetDescendants(string identityNumber)
    {
        try
        {
            var descendants = await _familyTreeService.GetDescendants(identityNumber);

            return Ok(new GenericResponseModel<List<PersonModel>>(true, "Descendants successfully retrieved",
                descendants));
        }
        catch (InvalidOperationException oe)
        {
            return BadRequest(new GenericResponseModel<List<PersonModel>>(false, oe.Message, new List<PersonModel>()));
        }
    }
}