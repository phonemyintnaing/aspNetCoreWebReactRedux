
using System;
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
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }
        public int StatusId { get; set; }
        public POStatus POStatus { get; set; }
        public string Note { get; set; }
        public DateTime PODate { get; set; } = DateTime.Now;
        public int UserId { get; set; }

    }
}
