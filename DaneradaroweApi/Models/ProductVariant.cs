using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        
        public string? PropertyName { get; set; } = string.Empty;
        public string? PropertyValue { get; set; } = string.Empty;
        public string? PropertyUnit { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public int RadarId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; } = default!;
        [JsonIgnore]
        public Radar Radar { get; set; } = default!;    

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
