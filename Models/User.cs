using InitCMS.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)] 
        [Remote(action: "VerifyEmail", controller: "Users")]
        public string UserEmail { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<POViewModel> POViewModels { get; set; }
    }

}
