using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication.ViewModel
{
    public class ProViewModel
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string TenPro { get; set; }
        [Required(ErrorMessage = "Mã không được để trống")]
        [Display(Name = "Mã danh mục")]
        public int IdCat { get; set; }

        [Display(Name = "Tên danh mục")]
        public int TenCat { get; set; }

    }
}
