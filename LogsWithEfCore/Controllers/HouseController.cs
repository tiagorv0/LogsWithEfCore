using LogsWithEfCore.Model.Dto;
using LogsWithEfCore.Service;
using Microsoft.AspNetCore.Mvc;

namespace LogsWithEfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class HouseController : ControllerBase
{
    private readonly IHouseService _houseService;

    public HouseController(IHouseService houseService)
    {
        _houseService = houseService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] HouseRequest request)
    {
        try
        {
            var response = await _houseService.AddAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] HouseRequest request)
    {
        try
        {
            var response = await _houseService.UpdateAsync(id, request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
