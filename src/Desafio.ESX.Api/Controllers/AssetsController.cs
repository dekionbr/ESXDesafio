using ApplicationCore.ESX.Interfaces;
using ApplicationCore.ESX.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.ESX.Api.Controllers
{
    public class AssetsController : BaseApiV1Controller
    {
        private readonly IAssetsAppService _assetsAppService;

        public AssetsController(IAssetsAppService assetsAppService)
        {
            _assetsAppService = assetsAppService;
        }

        [HttpPost()]
        public IActionResult Register([FromBody] CreateAssetsViewModel assets)
        {
            if (!ModelState.IsValid)
            {
                return BadResponse();
            }

            _assetsAppService.Register(assets);

            return Response(assets);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] AssetsViewModel assets)
        {
            if (!ModelState.IsValid)
            {
                return BadResponse();
            }

            _assetsAppService.Update(assets);

            return Response(assets);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _assetsAppService.Remove(id);

            return Response("Removido com sucesso");
        }

        [HttpGet()]
        [AllowAnonymous]
        public IActionResult List()
        {
            var assets = _assetsAppService.GetAll();

            return Response(assets);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var assets = _assetsAppService.GetById(id);

            return Response(assets);
        }
    }
}