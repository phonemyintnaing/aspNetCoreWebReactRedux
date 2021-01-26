using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int? POId { get; set; }
        [DisplayName("Product")]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
        public DateTime StockDate { get; set; }
        public int StockInStatus { get; set; }
        [DisplayName("User")]
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
