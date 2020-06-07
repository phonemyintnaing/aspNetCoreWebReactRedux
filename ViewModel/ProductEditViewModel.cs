
using System.ComponentModel.DataAnnotations.Schema;

namespace InitCMS.ViewModel
{
    public class ProductEditViewModel : ProductViewModel
    {
        public int Id { get; set; }
        public string PhtotPath { get; set; }
    }
}
