using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InitCMS.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public string SlipNumber { get; set; }

    }
}
