using SmartCity.Data.Context;
using SmartCity.Models;

public class ProductRepository : IProductRepository
{
    private readonly SmartCityContext _context;

    public ProductRepository(SmartCityContext context)
    {
        _context = context;
    }

    public IList<Product> GetAll()
    {
        IList<Product> products = new List<Product>();

        try
        {
            products = _context.Products.ToList();
        }
        catch (Exception)
        {
            throw;
        }

        return products;
    }

    public Product GetById(int id)
    {
        Product product = new Product();

        try
        {
            product = _context.Products.FirstOrDefault(p => p.Id == id);
        }
        catch (Exception)
        {
            throw;
        }

        return product;
    }

    public Product Create(Product product)
    {
        try
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(int id, Product product)
    {
        try
        {
            _context.Products.Update(product);
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
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}