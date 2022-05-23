using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneradaroweApi.Models
{
    public class CompositeImage
    {
        // attributes
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Url {  get; set; } = string.Empty;

        // foreign keys
        public int ProductID { get; set; }
        public int ScanID { get; set; }

        // relations
        public Product Product { get; set; } = default!;
        public Scan Scan { get; set; } = default!;

        // many to many relations
        public List<Radar> Radars { get; set; } = default!;
    }
}