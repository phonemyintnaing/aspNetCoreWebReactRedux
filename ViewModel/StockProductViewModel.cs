using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.ViewModel
{
    public class StockProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }
    }
}
