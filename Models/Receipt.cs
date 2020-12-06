using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Sale> Sale { get; set; }

    }

}
