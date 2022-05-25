using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneradaroweApi.Models {
    public class ImageSchema {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Range { get; set; }
        public Guid RadarID { get; set; }

        public Radar Radar { get; set; } = default!;

        public ICollection<Image>? Images { get; set; }
    }
}