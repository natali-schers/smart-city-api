using Microsoft.AspNetCore.Mvc;

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

        // GET: api/Product
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productDAL.GetAll();

            return Ok(products);
        }
    }
}
