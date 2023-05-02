using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication.Models
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ảnh không được để trống")]
        [Display(Name = "Ảnh")]
        public string Img { get; set; }

        public ICollection<Pro> Pros { get; set; }
    }
}
