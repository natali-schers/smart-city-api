using SmartCity.Models;

namespace SmartCity.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<GetProductDto> GetAll()
        {
            IList<Product> products = _productRepository.GetAll();

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

        public GetProductDto GetById(int id)
        {
            Product product = _productRepository.GetById(id);

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

            return _productRepository.Create(product);
        }

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

            _productRepository.Update(id, product);
        }

        public void Delete (int id)
        {
            _productRepository.Delete(id);
        }
    }
}
