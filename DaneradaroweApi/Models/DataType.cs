using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class DataType
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ScaleUrl { get; set; }
        public double ValueMin { get; set; }
        public double ValueMax { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; } = default!;
    }
}
