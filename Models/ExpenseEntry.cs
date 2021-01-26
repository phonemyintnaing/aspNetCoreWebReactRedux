using System;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class ExpenseEntry
    {
        public int Id { get; set; }
        [Display(Name="COA")]
        public int CoaId { get; set; }
        public Coa Coa { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n0}", ApplyFormatInEditMode = true)]
        public Decimal Amount { get; set; }
        [MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Person Created")]       
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
