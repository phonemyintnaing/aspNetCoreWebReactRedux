
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InitCMS.Models;

namespace InitCMS.ViewModel
{
    public class POViewModel
    {
        public int Id { get; set; }
        public int RefNumber { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }
        public int POStatusId { get; set; }
        public POStatus POStatus { get; set; }
        [MaxLength(1500)]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PODate { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
