using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Pro
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mô tả không được để trống")]
        [Display(Name = "Mô tả chi tiết")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Ảnh không được để trống")]
        [Display(Name = "Ảnh sản phẩm")]
        public string Img { get; set; }
        [Display(Name = "Mã danh mục")]
        public int IdCat { get; set; }

        public Cat Cat { get; set; }


    }
}
