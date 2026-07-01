using SmartCity.Models;

namespace SmartCity.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public IList<GetProductTypeDto> GetAll()
        {
            IList<ProductType> types = _productTypeRepository.GetAll();

            return types.Select(t => new GetProductTypeDto
            {
                Id = t.Id,
                Description = t.Description,
                IsCommercialized = t.IsCommercialized
            }).ToList();
        }

        public GetProductTypeDto GetById(int id)
        {
            ProductType t = _productTypeRepository.GetById(id);

            return new GetProductTypeDto
            {
                Id = t.Id,
                Description = t.Description,
                IsCommercialized = t.IsCommercialized
            };
        }

        public ProductType Create(CreateProductTypeDto productTypeDto)
        {
            ProductType productType = new ProductType
            {
                Description = productTypeDto.Description,
                IsCommercialized = productTypeDto.IsCommercialized
            };

            return _productTypeRepository.Create(productType);
        }

        public void Update(int id, UpdateProductTypeDto productTypeDto)
        {
            ProductType productType = new ProductType
            {
                Description = productTypeDto.Description,
                IsCommercialized = productTypeDto.IsCommercialized
            };

            _productTypeRepository.Update(id, productType);
        }

        public void Delete(int id)
        {
            _productTypeRepository.Delete(id);
        }
    }
}
