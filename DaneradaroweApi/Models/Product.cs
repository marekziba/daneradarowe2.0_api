using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneradaroweApi.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty; 

        // product-specific parameters
        public float? ElevationAngle { get; set; }      // PPI
        public int? MinHeight { get; set; }     // CMAX, VIL
        public int? MaxHeight { get; set; }     // CMAX, VIL
        public int? Height { get; set; }        // CAPPI, PCAPPI
        public int? StartRange { get; set; }    // PCAPPI
        public int? StopRange { get; set; }     // PCAPPI
        public float? ReflectivityThreshold { get; set; }   // EHT

        // foreign keys
        public Guid DataTypeID { get; set; }

        // 1:1 relationships
        public DataType DataType { get; set; } = default!;

        // 1:N relationships
        public List<Image>? Images { get; set; }
        public List<CompositeImage>? CompositeImages { get; set; }

        // M:N relationships
        public List<Scan> Scans { get; set; } = default!;
        public List<Radar> Radars { get; set; } = default!;
    }
}