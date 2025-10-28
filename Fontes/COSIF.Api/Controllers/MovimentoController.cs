
using COSIF.Application.Services;
using COSIF.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace COSIF.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentoController : ControllerBase
{
    private readonly IMovimentoService _service;
    public MovimentoController(IMovimentoService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var itens = await _service.GetMovimentosAsync();
        return Ok(itens);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MovimentoManual dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _service.InsertMovimentoAsync(dto);
        return Ok();
    }
}
