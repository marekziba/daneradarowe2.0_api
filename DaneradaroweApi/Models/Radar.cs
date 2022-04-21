using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneradaroweApi.Models
{
    public class Radar
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string CodeName { get; set; } = string.Empty;
        public float Lat { get; set; }
        public float Lon { get; set; }
        public bool IsDoppler { get; set; }
        public bool IsDP { get; set; }

        // 1:N relationships
        public List<Volume>? Volumes { get; set; }
        public List<Image>? Images { get; set; }
        
        // M:N relationships
        public List<CompositeImage>? CompositeImages { get; set; }
        public List<Scan>? Scans { get; set; }
        public List<Product>? Products { get; set; }
    }
}