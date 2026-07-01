using SmartCity.Data.Context;
using SmartCity.Models;

public interface IProductTypeRepository
{
    IList<ProductType> GetAll();

    ProductType GetById(int id);

    ProductType Create(ProductType productType);

    void Update(int id, ProductType productType);

    void Delete(int id);
}