
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class Store
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }
       
    }
}
