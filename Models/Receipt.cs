using System;
using System.ComponentModel.DataAnnotations;

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
   

}
