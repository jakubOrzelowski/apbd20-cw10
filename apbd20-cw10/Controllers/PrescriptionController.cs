using apbd20_cw10.DTOs;
using apbd20_cw10.Services;

namespace apbd20_cw10.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] NewPrescriptionDto request)
    {
        try
        {
            await _dbService.AddPrescriptionAsync(request);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}