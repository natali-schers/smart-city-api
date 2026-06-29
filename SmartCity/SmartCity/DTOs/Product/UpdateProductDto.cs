namespace SmartCity.Models
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }

        public string? Characteristics { get; set; }

        public decimal? AveragePrice { get; set; }

        public string? LogoUrl { get; set; }

        public bool IsActive { get; set; }

        public int ProductTypeId { get; set; }
    }
}
