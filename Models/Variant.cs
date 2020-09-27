using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InitCMS.Models
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }
        public string VarOptOne { get; set; }
        public decimal? VarOptTwo { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
