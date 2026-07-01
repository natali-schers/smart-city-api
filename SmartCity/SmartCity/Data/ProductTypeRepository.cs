using SmartCity.Data.Context;
using SmartCity.Models;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly SmartCityContext _context;

    public ProductTypeRepository(SmartCityContext context)
    {
        _context = context;
    }

    public IList<ProductType> GetAll()
    {
        IList<ProductType> productTypes = new List<ProductType>();

        try
        {
            productTypes = _context.ProductTypes.ToList();
        }
        catch (Exception)
        {
            throw;
        }

        return productTypes;
    }

    public ProductType GetById(int id)
    {
        ProductType productType = new ProductType();

        try
        {
            productType = _context.ProductTypes.FirstOrDefault(pt => pt.Id == id);
        }
        catch (Exception)
        {
            throw;
        }

        return productType;
    }

    public ProductType Create(ProductType productType)
    {
        try
        {
            _context.ProductTypes.Add(productType);
            _context.SaveChanges();
            return productType;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(int id, ProductType productType)
    {
        try
        {
            _context.ProductTypes.Update(productType);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            ProductType productType = _context.ProductTypes.FirstOrDefault(pt => pt.Id == id);

            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
