using Microsoft.AspNetCore.Mvc;

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

        // GET: api/ProductType
        [HttpGet]
        public IActionResult GetAll()
        {
            var productTypes = _productTypeDAL.GetAll();

            return Ok(productTypes);
        }
    }
}
