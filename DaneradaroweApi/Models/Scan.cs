using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class Scan
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public int Range { get; set; }
        public int Numele { get; set; }

        // 1:N relationships
        public ICollection<Volume>? Volumes { get; set; }
        public ICollection<Image>? Images { get; set; }
        public ICollection<CompositeImage>? CompositeImages { get; set; }

        // M:N relationships
        [JsonIgnore]
        public ICollection<Radar>? Radars { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
        public ICollection<ProductType>? ProductTypes { get; set; }
    }
}