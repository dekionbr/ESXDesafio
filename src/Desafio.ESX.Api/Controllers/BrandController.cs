using ApplicationCore.ESX.Interfaces;
using ApplicationCore.ESX.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.ESX.Api.Controllers
{
    public class BrandController : BaseApiV1Controller
    {
        private readonly IBrandAppService _brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        [HttpPost()]
        public IActionResult Register([FromBody] CreateBrandViewModel brand)
        {
            if (!ModelState.IsValid)
            {
                return BadResponse();
            }

            _brandAppService.Register(brand);

            return Response(brand);
        }

        [HttpPut()]
        public IActionResult Update([FromBody] BrandViewModel brand)
        {
            if (!ModelState.IsValid)
            {
                return BadResponse();
            }

            _brandAppService.Update(brand);

            return Response(brand);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _brandAppService.Remove(id);

            return Response("Removido com sucesso");
        }

        [HttpGet()]
        [AllowAnonymous]
        public IActionResult List()
        {
            var brands = _brandAppService.GetAll();

            return Response(brands);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var brand = _brandAppService.GetById(id);

            return Response(brand);
        }


        [HttpGet("{id}/assets")]
        public IActionResult GetAssetsByBrandId([FromRoute] int id)
        {
            var assets = _brandAppService.GetAllAssetsByBrandId(id);

            return Response(assets);
        }



    }
}