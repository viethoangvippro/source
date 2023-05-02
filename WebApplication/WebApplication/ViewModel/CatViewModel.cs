using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication.ViewModel
{
    public class CatViewModel
    {
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [Display(Name = "Tên danh mục")]
        public string TenCat { get; set; }
    }
}
