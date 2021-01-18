using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitCMS.Models
{
    public class Coa
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(16)]
        [Remote(action: "CheckCCode", controller: "Coas")]
        public string Code { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }
        [Display(Name = "Account Type")]
        public int CoaTypeId { get; set; }
        public CoaType CoaType { get; set; }
    }
}
