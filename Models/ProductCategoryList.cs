using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace MvcRoom.Models
{
    public class ProductCategoryList
    {
        [Key]
        public int CatId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; } 
        public int Org_InStock { get; set; }
        public int Update_InStock { get; set; }

   
        public ProductList ProductList { get; set; }
    }
}
