using SmartCity.Models;

namespace SmartCity.Services
{
    public interface IProductService
    {
        IList<GetProductDto> GetAll();

        GetProductDto GetById(int id);

        Product Create(CreateProductDto productDto);

        void Update(int id, UpdateProductDto productDto);

        void Delete(int id);
    }
}
