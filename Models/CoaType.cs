using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class CoaType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(3)]
        public string Label { get; set; }
        [MaxLength(10)]
        public string Description { get; set; }
        public ICollection<Coa> Coas { get; set; }
    }
}
