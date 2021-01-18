using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InitCMS.Models
{
    public class ExpenseEntry
    {
        public int Id { get; set; }
        [Display(Name="COA")]
        public int CoaId { get; set; }
        public Coa Coa { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:n0}", ApplyFormatInEditMode = true)]
        public Decimal Amount { get; set; }
        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        [Display(Name = "Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Person Created")]       
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
