using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneradaroweApi.Models
{
    public class Image
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Url { get; set; } = String.Empty;
        public DateTime Date { get; set; }

        public Guid RadarID { get; set; }
        public Guid ScanID { get; set; }
        public Guid ProductID { get; set; }

        public Radar Radar { get; set; } = default!;
        public Scan Scan { get; set; } = default!;
        public Product Product { get; set; } = default!;

    }
}
