using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcRoom.Models
{
    public class ProductList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }

        public List<ProductCategoryList> ProductCategoryLists { get; set; }

    }
}
