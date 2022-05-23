namespace DaneradaroweApi.Models
{
    public class ProductType
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = String.Empty;

        // 1:N relations
        public ICollection<Product>? Products { get; set; }

        // M:N relations
        public ICollection<Radar>? Radars { get; set; }
        public ICollection<Scan>? Scans { get; set; }
    }
}
