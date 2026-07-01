using Microsoft.AspNetCore.Mvc;
using SmartCity.Models;
using SmartCity.Services;

namespace SmartCity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var product = _productService.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto product)
        {
            var createProduct = _productService.Create(product);

            return Ok(createProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductDto product)
        {
            _productService.Update(id, product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            return Ok();
        }
    }
}
