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
        public async Task<IActionResult> CriarImovel(CriarImovelRequest request)
        {
            var result = await _imovelService.CriarImovelAsync(request);
            return result.ToActionResult();
        }
    }
}
