using Microsoft.AspNetCore.Mvc;
using SmartCity.Models;

namespace SmartCity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductDAL _productDAL;

        public ProductsController()
        {
            _productDAL = new ProductDAL();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productDAL.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var product = _productDAL.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto product)
        {
            _productDAL.Create(product);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductDto product)
        {
            _productDAL.Update(id, product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productDAL.Delete(id);

            return Ok();
        }
    }
}
