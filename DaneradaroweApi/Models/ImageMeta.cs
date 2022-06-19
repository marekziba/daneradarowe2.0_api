using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class ImageMeta
    {
        public int Id { get; set; }
        //public string MaskUrl { get; set; } = string.Empty;
        public string CodeName { get; set; } = string.Empty;

        public double Lat_ul { get; set; }
        public double Lon_ul { get; set; }
        public double Lat_lr { get; set; }
        public double Lon_lr { get; set; }

        public string MaskUrl { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Radar> Radars { get; set; } = new List<Radar>();
    }
}
