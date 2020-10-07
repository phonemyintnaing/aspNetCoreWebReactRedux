using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public string LabelDesc { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Quantity { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
