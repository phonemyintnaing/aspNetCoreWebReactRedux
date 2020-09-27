using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace InitCMS.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string BrandDesc { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
