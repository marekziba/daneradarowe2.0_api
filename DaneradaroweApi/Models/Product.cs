using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DaneradaroweApi.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductType { get; set; } = String.Empty;
        public string CodeName { get; set; } = String.Empty;
        public string FullName { get; set; } = String.Empty;

        public int DataTypeId { get; set; }
        public int ScanId { get; set; }

        public DataType DataType { get; set; }= default!;
        public Scan Scan { get; set; } = default!;

        public ICollection<ProductVariant>? Variants { get; set; }
        [JsonIgnore]
        public ICollection<Radar> Radars { get; set; } = default!;
    }
}