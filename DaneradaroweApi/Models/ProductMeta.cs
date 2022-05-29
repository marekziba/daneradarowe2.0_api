namespace DaneradaroweApi.Models
{
    public class ProductMeta
    {
        public int Id { get; set; }

        // bounding box definition
        public double lat_ul { get; set; }
        public double lon_ul { get; set; }
        public double lat_lr { get; set; }
        public double lon_lr { get; set; }
    }
}
