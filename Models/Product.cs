using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Product Code")]
        public string PCode { get; set; }
        public string Description { get; set; }
        [DisplayName("Purchse Price")]
        public decimal? PurchasePrice { get; set; }
        [DisplayName("Selling Price")]
        public decimal SellPrice { get; set; }
        [DisplayName("In Stock")]
        public int? InStock { get; set; }
        [DisplayName("Sale")]
        public int? Sale { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        public int ProductCategoryID { get; set; }
        public int CategoryCatId { get; set; }
        [DisplayName("Photo")]
        public string ImagePath { get; set; }
        [DisplayName("Product Category")]
        public ProductCategory ProductCategory { get; set; }
        public Category Category { get; set; }
        
    }
}
