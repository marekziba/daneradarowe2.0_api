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

        public double lat_ul { get; set; }
        public double lon_ul { get; set; }
        public double lat_lr { get; set; }
        public double lon_lr { get; set; }

        [JsonIgnore]
        public ICollection<Image> Images { get; set; } = new List<Image>();
        public ICollection<Radar> Radars { get; set; } = new List<Radar>();
    }
}
