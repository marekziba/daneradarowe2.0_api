using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneradaroweApi.Models
{
    public class Volume
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int RadarID { get; set; }
        public int ScanID { get; set; }

        public Radar Radar { get; set; } = default!;
        public Scan Scan { get; set; } = default!;
    }
}