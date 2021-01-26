using InitCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.ViewModel
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Code")]
        [Remote(action: "CheckPCode", controller:"Products")]
        public string PCode { get; set; }
        public string Description { get; set; }
        [MaxLength(1500)]
        [DataType(DataType.MultilineText)]
        public string LongDesc { get; set; }
        [DisplayName("Purchse Price")]
        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }
        [DisplayName("Selling Price")]
        [DataType(DataType.Currency)]
        public decimal SellPrice { get; set; }
        [DisplayName("In Stock")]
        public int? InStock { get; set; }
        [DisplayName("Sale")]
        public int? Sale { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Product Category")]
        public int ProductCategoryID { get; set; }
        [DisplayName("Category")]
        public int CategoryCatId { get; set; }
        [DisplayName("Unit")]
        public int UnitId { get; set; }
        [DisplayName("Brand")]
        public int? BrandId { get; set; }
        [DisplayName("Variant")]
        public int? VariantId { get; set; }

        [DisplayName("File Upload")]
        public IFormFile Photo { get; set; }
        [DisplayName("Category")]
        public ProductCategory ProductCategory { get; set; }
        public Category Category { get; set; }
        [DisplayName("Active")]
        public bool IsSelected { get; set; }
        public Brand Brand { get; set; }
        public Unit Unit { get; set; }     
        public Variant Variant { get; set; }
       
    }
}
