using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace InitCMS.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public string LabelDesc { get; set; }
        public decimal? Quantity { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
