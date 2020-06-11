using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string CatTitle { get; set; }
        public string CatDescription { get; set; }
        public ICollection<Product> Product { get; set; }

    }
}
