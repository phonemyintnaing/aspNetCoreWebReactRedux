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
        public int UnitId { get; set; }
        public int? BrandId { get; set; }
        public int? VariantId { get; set; }

        [DisplayName("File Upload")]
        public IFormFile Photo { get; set; }
        [DisplayName("Category")]
        public ProductCategory ProductCategory { get; set; }
        public Category Category { get; set; }
        public bool IsSelected { get; set; }
        public Brand Brand { get; set; }
        public Unit Unit { get; set; }     
        public Variant Variant { get; set; }
       
    }
}
