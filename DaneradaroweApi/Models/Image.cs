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
        public string MaskUrl { get; set; } = String.Empty;

        public int RadarID { get; set; }
        public int ScanID { get; set; }
        public int ProductID { get; set; }
        public int MetaID { get; set; }

        [JsonIgnore]
        public Radar Radar { get; set; } = default!;
        [JsonIgnore]
        public Scan Scan { get; set; } = default!;
        [JsonIgnore]
        public Product Product { get; set; } = default!;
        public ImageMeta Meta { get; set; } = default!;
    }
}
