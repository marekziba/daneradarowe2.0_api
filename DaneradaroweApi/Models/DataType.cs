﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DaneradaroweApi.Models
{
    public class DataType
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ScaleUrl { get; set; }

        public List<Product> Products { get; set; } = default!;
    }
}