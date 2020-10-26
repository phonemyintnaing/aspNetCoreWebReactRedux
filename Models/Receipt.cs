using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        public int StoreId { get; set; } 
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
      
    }
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int ProductId { get; set; } 
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

    }


}
