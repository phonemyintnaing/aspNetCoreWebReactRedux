using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InitCMS.ViewModel
{
    public class DailySaleViewModel
    {
        [Display(Name = "ReceiptNo")]
        public int ReceiptNumber { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Code")]
        public string PCode { get; set; }

        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Sale Person")]
        public string SalePerson { get; set; }
        public decimal Total { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        [BindRequired]
        public DateTime Date { get; set; }

    }
}
