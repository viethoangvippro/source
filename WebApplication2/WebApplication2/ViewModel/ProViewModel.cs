using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication2.ViewModel
{
    public class ProViewModel
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string NamePro { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string Price { get; set; }
        [Required(ErrorMessage = "Mã không được để trống")]
        [Display(Name = "Mã danh mục")]
        public int IdCat { get; set; }

        [Display(Name = "Tên danh mục")]
        public int NameCat { get; set; }
       


    }
}
