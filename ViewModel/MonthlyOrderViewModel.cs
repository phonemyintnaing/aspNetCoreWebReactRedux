using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;


namespace InitCMS.ViewModel
{
    public class MonthlyOrderViewModel
    {
        public string ProductName { get; set; }
        public string PCode { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        [BindRequired]
        public DateTime Date { get; set; }
    }
}
