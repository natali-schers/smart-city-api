using SmartCity.Models;

namespace SmartCity.Services
{
    public interface IProductTypeService
    {
        IList<GetProductTypeDto> GetAll();

        GetProductTypeDto GetById(int id);

        ProductType Create(CreateProductTypeDto productTypeDto);

        void Update(int id, UpdateProductTypeDto productTypeDto);

        void Delete(int id);
    }
}