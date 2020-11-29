using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
      
    }
}
