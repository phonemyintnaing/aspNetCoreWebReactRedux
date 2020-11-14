using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int POId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        public DateTime StockDate { get; set; }
        public int UserId { get; set; }
    }
}
