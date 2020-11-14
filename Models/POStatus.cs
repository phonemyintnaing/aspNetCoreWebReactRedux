using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class POStatus
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
    }
}
