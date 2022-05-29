using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class Radar
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string CodeName { get; set; } = string.Empty;
        public float? Lat { get; set; }
        public float? Lon { get; set; }
        public bool IsComposite { get; set; }

        public ICollection<ProductVariant>? ProductVariants { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        [JsonIgnore]
        public ICollection<ImageMeta> ImageMasks { get; set; } = new List<ImageMeta>();
    }
}