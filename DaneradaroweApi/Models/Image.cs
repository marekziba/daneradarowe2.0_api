using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = String.Empty;
        public DateTime Date { get; set; }

        // bounding box definition
        public double lat_ul { get; set; }
        public double lon_ul { get; set; }
        public double lat_lr { get; set; }
        public double lon_lr { get; set; }

        public Guid RadarID { get; set; }
        public Guid ScanID { get; set; }
        public Guid ProductID { get; set; }

        [JsonIgnore]
        public Radar Radar { get; set; } = default!;
        [JsonIgnore]
        public Scan Scan { get; set; } = default!;
        [JsonIgnore]
        public Product Product { get; set; } = default!;

    }
}
