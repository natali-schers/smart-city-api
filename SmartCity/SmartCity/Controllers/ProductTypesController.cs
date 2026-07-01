using Microsoft.AspNetCore.Mvc;
using SmartCity.Models;
using SmartCity.Services;

namespace SmartCity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypesController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productTypes = _productTypeService.GetAll();

            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productType = _productTypeService.GetById(id);

            return Ok(productType);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductTypeDto productType)
        {
            _productTypeService.Create(productType);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductTypeDto productType)
        {
            _productTypeService.Update(id, productType);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productTypeService.Delete(id);

            return Ok();
        }
    }
}
