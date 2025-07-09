using BuildYourPC.Application.DTOs.Components;
using BuildYourPC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildYourPC.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComponentController(IComponentService componentService) : ControllerBase
{
    private readonly IComponentService _componentService = componentService;

    [HttpPost("cpu")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCpu([FromBody] CreateCpuDto cpuDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var cpu = await _componentService.CreateCpuAsync(cpuDto);
            return CreatedAtAction(nameof(CreateCpu), new { id = cpu.Id }, cpu);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Lỗi khi tạo CPU: {ex.Message}");
        }
    }

    [HttpGet("cpus")]
    public async Task<IActionResult> GetList()
    {
        var a = await _componentService.GetCpus();
        return Ok(a);
    }
}
