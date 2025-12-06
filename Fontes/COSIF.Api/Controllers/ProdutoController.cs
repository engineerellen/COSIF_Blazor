using COSIF.Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace COSIF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var itens = await _service.GetProdutosAsync();
            return Ok(itens);
        }

        [HttpGet("{codProduto}")]
        public async Task<IActionResult> Get(string codProduto)
        {
            var item = await _service.GetProdutoByCodigoAsync(codProduto);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
    }
}
