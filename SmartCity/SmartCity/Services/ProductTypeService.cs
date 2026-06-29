using SmartCity.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartCity.Services
{
    public class ProductTypeService
    {
        private readonly ProductTypeDAL _productTypeDAL;

        public ProductTypeService()
        {
            _productTypeDAL = new ProductTypeDAL();
        }

        public IList<GetProductTypeDto> GetAll()
        {
            IList<ProductType> types = _productTypeDAL.GetAll();

            return types.Select(t => new GetProductTypeDto
            {
                Id = t.Id,
                Description = t.Description,
                IsCommercialized = t.IsCommercialized
            }).ToList();
        }

        public GetProductTypeDto GetById(int id)
        {
            ProductType t = _productTypeDAL.GetById(id);

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

            return _productTypeDAL.Create(productType);
        }

        public void Update(int id, UpdateProductTypeDto productTypeDto)
        {
            ProductType productType = new ProductType
            {
                Description = productTypeDto.Description,
                IsCommercialized = productTypeDto.IsCommercialized
            };

            _productTypeDAL.Update(id, productType);
        }

        public void Delete(int id)
        {
            _productTypeDAL.Delete(id);
        }
    }
}
