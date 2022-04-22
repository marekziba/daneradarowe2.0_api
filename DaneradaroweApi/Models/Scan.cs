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
        public Guid Id { get; set; }
        public string name { get; set; } = string.Empty;
        public int Range { get; set; }
        public int Numele { get; set; }

        // 1:N relationships
        public List<Volume>? Volumes { get; set; }
        public List<Image>? Images { get; set; }
        public List<CompositeImage>? CompositeImages { get; set; }

        // M:N relationships
        [JsonIgnore]
        public List<Radar>? Radars { get; set; }
        public List<Product>? Products { get; set; }
    }
}