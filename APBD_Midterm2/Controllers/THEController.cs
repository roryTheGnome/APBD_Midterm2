using APBD_Midterm2.DTOs;
using APBD_Midterm2.Services;
using APBD_Midterm2.Data;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Midterm2.Controllers;

[ApiController]
[Route("api")]
public class THEController: ControllerBase
{
    //since i have only 1 controller i dont think i need a folder of Controllers
    //but i do not want to delete it so from now on i shall call this one The Controller to controll em all
    
    private readonly IDbService _service;
    public THEController(IDbService service) => _service = service;

    [HttpGet("customers/{id}/purchases")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _service.GetCustomerPurchases(id);
            return Ok(result);
        }
        catch (Exception e) { return NotFound(e.Message); }
    }

    [HttpPost("washing-machines")]
    public async Task<IActionResult> Post(NewMachineRequest req)
    {
        try
        {
            await _service.AddWashingMachineAsync(req);
            return Ok();
        }
        catch (Exception e) { return BadRequest(e.Message); }
    }
}