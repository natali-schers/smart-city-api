using Microsoft.AspNetCore.Mvc;
using SmartCity.Models;

namespace SmartCity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypesController : Controller
    {
        private readonly ProductTypeDAL _productTypeDAL;

        public ProductTypesController()
        {
            _productTypeDAL = new ProductTypeDAL();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productTypes = _productTypeDAL.GetAll();

            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var productType = _productTypeDAL.GetById(id);

            return Ok(productType);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductType productType)
        {
            _productTypeDAL.Create(productType);

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductType productType)
        {
            _productTypeDAL.Update(productType);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productTypeDAL.Delete(id);

            return Ok();
        }
    }
}
