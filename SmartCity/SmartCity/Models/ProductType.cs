namespace SmartCity.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public bool IsCommercialized { get; set; }

        public IList<Product>? Products { get; set; }
    }
}
