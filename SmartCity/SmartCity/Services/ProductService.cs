using SmartCity.Models;

namespace SmartCity.Services
{
    public class ProductService
    {
        private readonly ProductDAL _productDAL;

        public ProductService ()
        {
            _productDAL = new ProductDAL ();
        }

        /// <summary>
        /// Recupera todos os produtos cadastrados
        /// </summary>
        /// <returns></returns>
        public IList<GetProductDto> GetAll()
        {
            IList<Product> products = _productDAL.GetAll();

            return products.Select(p => new GetProductDto
            {
                ProductName = p.ProductName,
                Id = p.Id,
                AveragePrice = p.AveragePrice,
                Characteristics = p.Characteristics,
                IsActive = p.IsActive,
                LogoUrl = p.LogoUrl,
                ProductTypeId = p.ProductTypeId,
            }).ToList();
        }

        /// <summary>
        /// Recupera as informações de um produto de acordo com o id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetProductDto GetById(int id)
        {
            Product product = _productDAL.GetById(id);

            GetProductDto productDto = new GetProductDto()
            {
                ProductName = product.ProductName,
                Id = product.Id,
                AveragePrice = product.AveragePrice,
                Characteristics = product.Characteristics,
                IsActive = product.IsActive,
                LogoUrl = product.LogoUrl,
                ProductTypeId = product.ProductTypeId
            };

            return productDto;
        }
    
        /// <summary>
        /// Registra um produto
        /// </summary>
        /// <param name="productDto"></param>
        public Product Create(CreateProductDto productDto)
        {
            Product product = new Product()
            {
                ProductName = productDto.ProductName,
                AveragePrice = productDto.AveragePrice,
                Characteristics = productDto.Characteristics,
                IsActive = productDto.IsActive,
                LogoUrl = productDto.LogoUrl,
                ProductTypeId = productDto.ProductTypeId
            };

            return _productDAL.Create(product);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="productDto"></param>
        public void Update(int id, UpdateProductDto productDto)
        {
            Product product = new Product()
            {
                ProductName = productDto.ProductName,
                AveragePrice = productDto.AveragePrice,
                Characteristics = productDto.Characteristics,
                IsActive = productDto.IsActive,
                LogoUrl = productDto.LogoUrl,
                ProductTypeId = productDto.ProductTypeId
            };

            _productDAL.Update(id, product);
        }

        /// <summary>
        /// Deleta o registro de um produto de acordo com o id
        /// </summary>
        /// <param name="id"></param>
        public void Delete (int id)
        {
            _productDAL.Delete(id);
        }
    }
}
