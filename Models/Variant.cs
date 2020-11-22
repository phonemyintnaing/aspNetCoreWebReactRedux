using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.Models
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }
        public string VarOptOne { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? VarOptTwo { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
