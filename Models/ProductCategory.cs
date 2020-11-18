
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public ICollection<Product> Product { get; set; }

    }
}
