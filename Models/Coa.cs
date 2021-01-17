using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class Coa
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(16)]
        public string Code { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }
        public int CoaTypeId { get; set; }
        public CoaType CoaType { get; set; }
    }
}
