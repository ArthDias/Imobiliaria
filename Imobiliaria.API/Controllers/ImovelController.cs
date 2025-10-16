using Imobiliaria.Application.Requests.Imovel;
using Imobiliaria.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController(IImovelService imovelService) : ControllerBase
    {
        private readonly IImovelService _imovelService = imovelService;

        [HttpPost]
        public async Task<IActionResult> CriarImovel([FromBody] CriarImovelRequest request)
        {
            var result = await _imovelService.CriarImovelAsync(request);
            return result.ToActionResult();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarImovelById(int id)
        {
            var result = await _imovelService.BuscarImovelByIdAsync(id);
            return result.ToActionResult();
        }
        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var result = await _imovelService.BuscarTodosAsync();
            return result.ToActionResult();
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarImovel([FromQuery] int id, [FromBody] AtualizarImovelRequest imovel)
        {
            var result = await _imovelService.AtualizarAsync(id, imovel);
            return result.ToActionResult();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletarImovel([FromQuery] int id)
        {
            var result = await _imovelService.DeletarImovelAsync(id);
            return result.ToActionResult();
        }
    }
}
