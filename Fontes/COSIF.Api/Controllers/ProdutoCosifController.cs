using COSIF.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace COSIF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoCosifController : ControllerBase
    {
        private readonly ICosifService _service;
        public ProdutoCosifController(ICosifService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itens = await _service.GetCosifsAsync();
            return Ok(itens);
        }

        [HttpGet("codProduto")]
        public async Task<IActionResult> Get(string codProduto)
        {
            var itens = await _service.GetCosifByProdutoAsync(codProduto);
            return Ok(itens);
        }
    }
}