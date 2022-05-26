namespace DaneradaroweApi.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        public string SpecDef { get; set; } = String.Empty;

        // product-specific parameters
        public float? ElevationAngle { get; set; }      // PPI
        public int? MinHeight { get; set; }     // CMAX, VIL
        public int? MaxHeight { get; set; }     // CMAX, VIL
        public int? Height { get; set; }        // CAPPI, PCAPPI
        public int? StartRange { get; set; }    // PCAPPI
        public int? StopRange { get; set; }     // PCAPPI
        public float? ReflectivityThreshold { get; set; }   // EHT

        public Product Product { get; set; } = default!;

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
