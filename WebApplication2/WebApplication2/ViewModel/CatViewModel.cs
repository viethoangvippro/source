using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication2.ViewModel
{
    public class CatViewModel
    {
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [Display(Name = "Tên danh mục")]
        public string NameCat { get; set; }
        public string Img { get; set; }
    }
}
