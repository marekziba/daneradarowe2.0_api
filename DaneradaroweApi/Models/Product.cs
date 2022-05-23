using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public int Range { get; set; }

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
        public Guid ScanID { get; set; }

        // 1:1 relationships
        public DataType DataType { get; set; } = default!;
        public Scan Scan { get; set; } = default!;
        [JsonIgnore]
        public ProductType ProductType { get; set; } = default!;

        // 1:N relationships
        public ICollection<Image>? Images { get; set; }
        public ICollection<CompositeImage>? CompositeImages { get; set; }

        // M:N relationships
        [JsonIgnore]
        public ICollection<Radar> Radars { get; set; } = default!;
    }
}