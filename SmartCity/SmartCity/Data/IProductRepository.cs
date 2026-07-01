using SmartCity.Data.Context;
using SmartCity.Models;

public interface IProductRepository
{
    IList<Product> GetAll();

    Product GetById(int id);

    Product Create(Product product);

    void Update(int id, Product product);

    void Delete(int id);
}     