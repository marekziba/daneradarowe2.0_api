namespace DaneradaroweApi.Models
{
    public class ProductGroup
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int range { get; set; }

        public ProductType ProductType { get; set; } = default!;
        public Scan Scan { get; set; } = default!;
        public DataType DataType { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = default!;
    }
}
